    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace StackOverflowConsole
    {
       public class EmptyClass
       {
       }
    
       public class ReferenceStuff : EmptyClass
       {
          object a;
       }
    
       public class TypeStuff : EmptyClass
       {
          int a;
       }
    
       class Test
       {
          static void Main()
          {
             ReferenceStuff r = new ReferenceStuff();
             TypeStuff t = new TypeStuff();
    
             if (r is EmptyClass)
             {
               Console.WriteLine("r is an EmptyClass");
             }
             if (t is EmptyClass)
             {
                Console.WriteLine("t is an EmptyClass");
             }
          }
       }
    }
