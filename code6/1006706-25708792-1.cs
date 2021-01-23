    class Program
    {   
        private static void Main(string[] args)
        {
            var i = Calcolatrice.Somma(12, 3);
            var j = Calcolatrice.Sottrazione(45, 34);
            Console.WriteLine(i);
    
        }
    
        public static class Calcolatrice
        {
            public static int Somma(int x, int y)
            {
                return x + y;
            }
    
            public static int Sottrazione(int x, int y)
            {
                return x - y;
            }
        }    
    }
