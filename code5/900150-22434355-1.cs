    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    using MyLibraryProject;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                MathLibraryClass myclass = new MathLibraryClass();
                int sum = myclass.Sum(12, 4);
                Console.WriteLine("sum is {0}", sum);
            }
        }
    }
