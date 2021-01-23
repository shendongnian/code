        using System;
    
    namespace ConsoleApplication1
    {
        public enum shape{
            square,
            triangle
        }
        class Program
        {
    
            static void Main(string[] args)
            {
                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        Console.SetCursorPosition(j,i);
                        if (IsInShape(shape.square ,i,j))
                        {
                            Console.Write("*");
                        }
                    }
                }
                Console.ReadLine();
            }
    
            public static bool IsInShape(shape s, int i, int j)
            {
                if (s == shape.square)
                {
                    return ((Math.Pow((i - 7), 2) + Math.Pow((j - 7), 2)) <= 12);
                }
                else
                {
                    return (j - i > 0 && j+i < 6);
                }
            }
    
        }
    }
