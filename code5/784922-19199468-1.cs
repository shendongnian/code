        static void Main(string[] args)
        {
            string numberIn = Console.ReadLine();
            int numberOut;
            while(!IsNumeric(numberIn))
            {
                Console.WriteLine("Invalid.  Enter a number that's 0 or higher.");
                numberIn = Console.ReadLine();
            }
            numberOut = int.Parse(numberIn);
        }
        private static bool IsNumeric(string num)
        {
            return num.ToCharArray().Where(x => !Char.IsDigit(x)).Count() == 0;
        }
