    using System;    
    namespace ConsoleApplication1
    {    
       class Program
    {        
        static int triangles = 4;
        static int lines = 10;
        static void Main(string[] args)
        {           
            for (int i = 1; i <= triangles; i++)
            {
                if (i==1||i==4)
                {
                    for (int j = 1; j <= lines; j++)                    
                        writeAstrix(i, j);                    
                }
                else
                {
                    for (int j = lines; j > 0; j--)                    
                        writeAstrix(i, j);
                }              
                Console.WriteLine();
            }
            Console.ReadLine();
        }
        private static void writeAstrix(int i, int j)
        {           
            if (i == 3||i==4)
                makeSpacers(j);
            while (j > 0)
            {
                Console.Write('*');
                j--;
            }
            Console.WriteLine();
        }
        private static void makeSpacers(int iterate)
        {
            int spacers = lines - iterate;
            while (spacers > 0)
            {
                Console.Write(' ');
                spacers--;
            }
        }
     }    
    }
