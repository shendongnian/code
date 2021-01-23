     class Program
        {
            static void Main(string[] args)
            {
                System.DateTime dtTodayNoon = new System.DateTime(2006, 9, 13, 12, 0, 0);
                System.DateTime dtTodayMidnight = new System.DateTime(2006, 9, 13, 0, 0, 0);
                System.TimeSpan diffResult = dtTodayNoon.Subtract(dtYestMidnight);
                Console.WriteLine("Yesterday Midnight - Today Noon = " + diffResult.Days);
                Console.WriteLine("Yesterday Midnight - Today Noon = " + diffResult.TotalDays);
                Console.ReadLine();
            }
        }
