    static void Main(string[] args)
    {
        // To keep short, I have not added any validation, but the user input
        // should always validated See double.TryParse 
        Console.Write("Enter first integer: ");
        double num1 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter operator (+,-,*, / or %)");
        string oper = Convert.ToString(Console.ReadLine());
        Console.Write("Enter second integer: ");
        double num2 = Convert.ToDouble(Console.ReadLine());
        SimpleCalc calc = new SimpleCalc(num1, num2, oper);
        double result = calc.Execute();
        Console.WriteLine("Answer is: {0}", result);
    }
    class SimpleCalc
    {
        double _num1;
        double _num2;
        string _oper;
        public SimpleCalc(double num1, double num2, string oper)
        {
            _num1 = num1;
            _oper = oper;
            _num2 = num2;
        }
        public double Execute()
        {        
            if (oper == "+")
                return num1 + num2;
            else if (oper == "-")
                return num1 - num2;
            else if (oper == "*")
                return num1 * num2;
            else if (oper == "/")
                return num1 / num2;
            else if (oper == "%")
                return num1 % num2;
            else 
                 throw new ArgumentException("Invalid operator: " + oper);
        }
    }
