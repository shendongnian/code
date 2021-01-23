        static void Main(string[] args)
        {
            while (AskForDate())
            {}
        }
        private static bool AskForDate()
        {
            Console.WriteLine("please enter m,y,n: \n");
            string input = Console.ReadLine();
            string[] split = input.Split(' ');
            int month = Int32.Parse(split[0]);
            int year = Int32.Parse(split[1]);
            int numberOfMonths = Int32.Parse(split[2]);
            int i = 0;
            for (i = 0; i < numberOfMonths; i++)
            {
                GenMonth(month, year);
                month++;
                Console.Write("\n \n");
            }
            if (month > 12)
            {
                month = 1;
                year++;
            }
            Console.Out.WriteLine("Again? [Y/n]");
            var key = Console.ReadKey();
            return key.Key != ConsoleKey.N;
        }
