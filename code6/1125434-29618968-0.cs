    using System;
    namespace TESETER
    {
        class Program
        {
            static void Main(string[] args)
        {
            int q, moj = 0;
            int[][] arr = new int[1][];
            int[][] b = new int[1][];
            // b = arr;
            // arr[0] = new int[1];
            // Array.Copy(arr[0], b[0]);
            while (moj < 3)
            {
                Console.WriteLine("interger");
                int.TryParse(Console.ReadLine(), out q);
                if (moj < 1)
                { arr[0][0] = q; moj++; }
                else
                {
                    moj++; arr[0] = new int[moj];
                    for (int i = 0; i < moj - 1; i++)
                    {
                        arr[0][i] = b[0][i];
                    }
                    arr[0][moj - 1] = q;
                    Array.Copy(arr, b);
                    //b[0] = arr[0];
                }
            }
            Console.WriteLine(arr[0][0]);
            Console.WriteLine(arr[0][1]);
            Console.WriteLine(arr[0][2]);
            Console.ReadLine();
        }
    }
    }
