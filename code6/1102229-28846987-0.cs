    using System.IO;
    using System;
    
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Below are prime numbers between 0 and 10000!");
            Console.WriteLine(2);
            for(int i=3;i<=10000;i++)
            {
                bool isPrime=true;
                for(int j=2;j<=Math.Sqrt(i);j++)
                {
                    if(i%j==0)
                    {
                        isPrime=false;
                        break;
                    }
                }
                if(isPrime)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
