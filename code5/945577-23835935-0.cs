    class MainClass
    {
        public static void Main(string[] args)
        {
            var n = 5m;
            Console.WriteLine(Executioner.GetRate(n)); // -> prints 15
            // provides a new method to be called
            Executioner.GetRateFunc = a => a * 2;
            Console.WriteLine(Executioner.GetRate(n)); // -> prints 10
        }
    }
    public static class Executioner
    {
        private static decimal MyGetRate(decimal a)
        {
            return (a < 100) ? a * 3 : a * 2;
        }
        public static Func<decimal, decimal> GetRateFunc { get; set; }
        public static decimal GetRate(decimal a)
        {
            var f = GetRateFunc ?? MyGetRate;
            return f (a);
        }
    }
