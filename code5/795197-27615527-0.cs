    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.Write("Coefficient Of x (Positive): ");
                int coef = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Value Of c: ");
                int c = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("From? (Positive)");
                int from = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("To? (Positive)");
                int to = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                int[] y_val = new int[(to - from) + 1];
                int counter = 0;
                for (int i = to; i >= from; i--)
                {
                    y_val[counter] = ((coef * i) + c);
                    counter++;
                }
                int x = 0;
                for (int i = to; i >= from; i--)
                {
                    if (y_val[x] == ((coef * i) + c))
                    {
                        if (y_val[x] >= 10)
                        {
                            Console.WriteLine("{0}|", y_val[x]);
                        }
                        else
                        {
                            Console.WriteLine("0{0}|", y_val[x]);
                        }
                        for (int j = 0; j < i; j++)
                        {
                            Console.Write("  ");
                        }
                        Console.Write("*");
                        Console.WriteLine();
    
                    }
                    x++;
                }
                Console.WriteLine("______________________________________________________________");
                Console.WriteLine("0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23");
                Console.ReadKey();
            }
        }
    }
