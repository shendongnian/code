    using System;
    // referencing System.Numerics.dll
    using System.Numerics;
    namespace ConsoleApplication1
    {
        class Program 
        {
            static void Main(string[] args) 
            {
                BigInteger bigInt = new BigInteger(2);
                bigInt = BigInteger.Pow(bigInt, 1000);
                Console.Out.WriteLine(bigInt.ToString());
            }
        }
    }
