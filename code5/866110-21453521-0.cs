    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace workingWithClasses
    {
        class meth1
        {
            //note statics
            static int op1;
    
            static int multiply(int mult)
            {
                return op1 = 44 * mult;
            }
        }
    
        class meth2
        {
            public int CallFuncsClass(int multiplicator)
            {
                //access to multiply() is valid here
                return meth1.multiply(int multiplicator);
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                meth1 m1 = new meth1();
                meth2 m2 = new meth2();
    
                m2.CallFuncsClass(3);
                int result_m1 = m1.op1;         
    
                Console.WriteLine(opm1);
                Console.ReadKey();
            }
        }
    }
