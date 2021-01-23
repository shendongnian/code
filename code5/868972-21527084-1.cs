        public SimpleCalc()
        {
            double num1;
            double num2;
            string oper;
            Console.Write("Enter first integer: ");
            num1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter operator (+,-,*, / or %)");
            oper = Convert.ToString(Console.ReadLine());
            Console.Write("Enter second integer: ");
            num2 = Convert.ToDouble(Console.ReadLine());
            if (oper == "+")
                Console.Write("Answer is: {0}", num1 + num2);
            if (oper == "-")
                Console.Write("Answer is: {0}", num1 - num2);
            if (oper == "*")
                Console.Write("Answer is: {0}", num1 * num2);
            if (oper == "/")
                Console.Write("Answer is: {0}", num1 / num2);
            if (oper == "%")
                Console.Write("Answer is: {0}", num1 % num2);
            Console.ReadKey();
        }
