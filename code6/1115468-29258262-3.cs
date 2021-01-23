    class Program
    {
        public static bool IsDateBeforeOrToday(string input)
        {
            DateTime inputTime;
            var parseResult = DateTime.TryParse(input, inputTime);
            if (!parseResult)
                //Do something useful if parse failed.
            return inputTime <= DateTime.Now
        }
        static void Main(string[] args)
        {
            Console.WriteLine(IsDateBeforeOrToday("03/26/2015"));
            Console.ReadKey();
        }
    }
