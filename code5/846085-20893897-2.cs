    using System;
    static class Program
    {
        public static char Car0 = 'A';
        public static char Car1 = 'B';
        public static char Car2 = 'C';
        public static char Car3 = 'D';
        public static char Car4 = 'E';
        public static char Car5 = 'F';
        public static char Car6 = 'G';
        public static char Car7 = 'H';
        public static char Car8 = 'I';
        public static char Car9 = 'J';
        static void Main()
        {
            var type = typeof(Program);
            for (int i = 0; i <= 9; i++)
            {
                var field = type.GetField("Car" + i);
                var temp = field.GetValue(null);
                Console.WriteLine("Car" + i + ": " + temp);
            }
        }
    }
