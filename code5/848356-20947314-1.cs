    using System;
    using FSharp.Sample;
    namespace CSharp.Sample.Console
    {
        class Program
        {
            static void Main()
            {
                double[][] image = new double[1000][];
                Random rand = new Random();
                for (int i = 0; i &lt; 1000; i ++ )
                {
                    image[i] = new double[3];
                    image[i][0] = rand.Next();
                    image[i][1] = rand.Next();
                    image[i][2] = rand.Next();
                }
                foreach (var doubles in MyFunctions.Process(image))
                {
                    System.Console.WriteLine(doubles);
                } 
            }
        }
    }
