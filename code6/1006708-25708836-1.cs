    internal class Program
    {   
       private static void Main(string[] args)
        {   
            var i = Calcolatrice.Somma(12, 3);
            var j = Calcolatrice.Sottrazione(45, 34);
            Console.WriteLine("i = " + i.toString());
            Console.WriteLine("j = " + j.toString());
            Console.ReadLine(); //Press Return to continue    
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
     
