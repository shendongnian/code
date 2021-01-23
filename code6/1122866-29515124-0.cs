        static void Main(string[] args)
        {
            for (var i = 1; i < 12; i++)
            {
                DateTime date = new DateTime(2015, i, 13);
                if (date.DayOfWeek == DayOfWeek.Friday)
                    Console.WriteLine(date.ToShortDateString());
            }
                 
            Console.ReadLine();
        }
