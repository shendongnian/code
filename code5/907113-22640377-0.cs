    class Program
    {
        enum Days
        {
            Sun,
            Mon,
            Tue,
            Wed,
            Thu,
            Fri,
            Sat
        };
        static void Main(string[] args)
        {
            Days obj = Days.Mon;
            Console.WriteLine(obj.ToString("G"));  // output - Mon (Normal)
            Console.WriteLine(obj.ToString("D"));  // output - 1 (Decimal)
            Console.WriteLine(obj.ToString("X"));  // output - 00000001 (Hexadecimal)    
        }
    }
