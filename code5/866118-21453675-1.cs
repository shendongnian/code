    namespace workingWithClasses
    {
        public class meth1
        {
            public int op1;
    
            public int multiply(int mult)
            {
                return op1 = 44 * mult;
            }
        }
    
        public class meth2
        {
            meth1 m1 = new meth1();
            public int CallFuncsClass(int multiplicator)
            {
                return m1.multiply( multiplicator);
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
               meth2 m2 = new meth2();
               int result_m2 = m2.CallFuncsClass(3);
               Console.WriteLine(result_m2);
               Console.ReadKey();
            }
        }
    }
