        public SimpleCalc(double num1, double num2, string oper)
        {
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
           
