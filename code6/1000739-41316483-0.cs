    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace While_loop
    {
        class Program
        {
            static void Main(string[] args)
            {
                int i = 1;
                Console.WriteLine(i);
                while (i < 10)
                {
                            for (int j = 1; j < 5; j++)
                      {
                            i = i + j;
                            Console.WriteLine(i);  
                      }
                    i++;
                }
          
                Console.ReadKey();
            }
        }
    }
