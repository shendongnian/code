        static void Main(string[] args)
        {
            var parsedDate = DateTime.ParseExact("2014$05$01", "yyyy$MM$dd", DateTimeFormatInfo.CurrentInfo);
            Console.WriteLine("Year: {0}",parsedDate.Year);
            Console.WriteLine("Month: {0}",parsedDate.Month);
            Console.WriteLine("Day: {0}",parsedDate.Day);
            Console.ReadLine();
        }
