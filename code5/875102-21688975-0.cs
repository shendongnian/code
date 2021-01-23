    class GetUserInput
    {
        public int GetFactorialNumber()
        {
            Console.Write("Enter number: ");
            int number;
            bool result = Int32.TryParse(Console.ReadLine(), out number);
            while (!result)
            {
                Console.WriteLine("Error!");
                GetFactorialNumber();
            }
            return number;
        }
    }
