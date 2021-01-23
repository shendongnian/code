    using System;
    using System.Linq;
    namespace pruebaDeNumerosAleatorios
    {
    class MainClass
    {
        public static int RandomNumber()
        {
            Random x = new Random(Guid.NewGuid().ToByteArray().First());
            return x.Next(0, 20);
        }
        public static void Main(string[] args)
        {
            for (int i = 0; i < 20; i++)
                Console.WriteLine(RandomNumber());
        }
    }
    }
