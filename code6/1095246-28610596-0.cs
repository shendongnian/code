    using System;
    class Program
    {
        static void Main(string[] args)
        {
            int tal1, tal2;
            int slinga;
            tal2 = Convert.ToInt32(Console.ReadLine());
            for (slinga = 0; slinga < 2; slinga++)
            {
                if (tal1 == 56)
                {
                    Console.WriteLine(Addera(slinga, tal1));
                    tal2--;
                }
                else
                    tal1 = 56;
            }
        }
        static int Addera(int tal1, int tal2)
        {
            return tal1 + tal2;
        }
    }
