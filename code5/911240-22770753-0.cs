    class Program 
    {
        static void Main(string[] args)
        {
            string date = "10/16/13";
            //This is usually the safer way to go
            DateTime result;
            if(DateTime.TryParse(date, out result))
                Console.WriteLine(result);
            //I think this is what you were trying to accomplish
            DateTime result2 = Convert.ToDateTime(date, CultureInfo.InvariantCulture);
            Console.ReadKey();
        }
    }
