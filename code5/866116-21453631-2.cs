    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace workingWithClasses
    {
        class meth1
        {
            public int op1;
    
            public int multiply(int mult)
            {
                return op1 = 44 * mult;
            }
        }
    
        class meth2
        {
            public int CallFuncsClass(int multiplicator)
            {
                meth1 m1=new meth1();
                return m1.multiply(multiplicator);
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                meth2 m2 = new meth2();
    
                int result_m1=m2.CallFuncsClass(3);
    
                Console.WriteLine(result_m1);
                Console.ReadKey();
            }
        }
    }
