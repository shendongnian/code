        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            DisplayTitle();
            InputData();
            DisplayOutput(CalculatePay(40, 50, 60), CalculateTax(4, CalculatePay(40, 50, 60)));
            TerminateProgram();
        }
