    using System;
    using System.Text;
    namespace Demo
    {
        internal class Program
        {
            private void run()
            {
                int[,] productsArray = new int[4, 5];
                for (int i = 0, k = 1; i < 4; ++i)
                    for (int j = 0; j < 5; ++j, ++k)
                        productsArray[i, j] = k;
                Console.WriteLine(format(productsArray));
            }
            private string format(int[,] productsArray)
            {
                var text = new StringBuilder();
                text.Append("        Monday  Tuesday  Wednesday  Thursday  Friday\n");
                for (int i = 0; i < productsArray.GetLength(0); ++i)
                {
                    text.AppendFormat
                    (
                        "week {0} {1,7} {2,8} {3,10} {4,9} {5,7}\n",
                        i+1,
                        productsArray[i, 0],
                        productsArray[i, 1],
                        productsArray[i, 2],
                        productsArray[i, 3],
                        productsArray[i, 4]
                    );
                }
                return text.ToString();
            }
            private static void Main()
            {
                new Program().run();
            }
        }
    }
