using System;

namespace CommandPattern
{
    /// <summary>
    /// The 'ConcreteCommand' class
    /// </summary>
    internal class CalculatorCommand : ICommand
    {
        private char _operation;
        private int _operand;
        private Receiver _calculator;

        // Constructor
        public CalculatorCommand(Receiver calculator,
          char operation, int operand)
        {
            _calculator = calculator;
            _operation = operation;
            _operand = operand;
        }

        // Gets operator
        public char Operator
        {
            set { _operation = value; }
        }

        // Get operand
        public int Operand
        {
            set { _operand = value; }
        }

        // Execute new command
        public void Execute()
        {
            _calculator.Operation(_operation, _operand);
        }

        // Unexecute last command
        public void UnExecute()
        {
            _calculator.Operation(Undo(_operation), _operand);
        }

        // Returns opposite operator for given operator
        private char Undo(char @operator)
        {
            switch (@operator)
            {
                case '+': return '-';
                case '-': return '+';
                case '*': return '/';
                case '/': return '*';
                default:
                    throw new ArgumentException("@operator");
            }
        }
    }
}