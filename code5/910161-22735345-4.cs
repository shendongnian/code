    class Program
    {
        private const int totalDays = 100;
        private const int minTemp = -10;
        private const int maxTemp = 50;
        private static Day[] days = new Day[totalDays];
        private static Random x = new Random();
        static void Main(string[] args)
        {
            double sum = 0;
            for (int i = 0; i < totalDays; i++)
            {
                days[i] = new Day(x.Next(minTemp, maxTemp + 1)); //Create a day with random temperature
                sum += days[i].Temperature;
                Console.WriteLine("Day {0} is {1} degrees and is{2} frosty", i, days[i].Temperature, days[i].Frost ? string.Empty : " not");
            }
            double average = sum / totalDays;
            Console.WriteLine("Total Temperature: {0} °C", sum);
            Console.WriteLine("Average Temperature {0} °C", average.ToString("F2"));
            for (int i = 0; i < totalDays; i++)
            {
                if (days[i].Frost)
                {
                    //Do something
                }
            }
            Console.ReadLine();
        }
    }
    public class Day
    {
        public int Temperature { get; set; }
        public bool Frost { get { return Temperature < 0; } }
        public Day(int temperature)
        {
            Temperature = temperature;
        }
    }
