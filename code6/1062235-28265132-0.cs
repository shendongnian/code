    class MainProgram
    {
        public static void Main(string[] args)
        {
            decimal DNumber = 1223456.45600000M;
            Console.WriteLine("Original Decimal Number = {0}, Decimal Number Without Zeros = {1}", DNumber, DNumber.ToString("#.##############"));
            Console.Read();
        }
    }
