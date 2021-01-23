        static void Main(string[] args)
        {
            Console.WriteLine(String.Format(CultureInfo.CurrentCulture, "Rebate {0}% during {1:hh} h {1:mm} min", 0.15, new TimeSpan(DateTime.Now.Ticks)));
            Console.ReadKey();
        }
