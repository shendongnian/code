    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace Example
    {
        class Program
        {
    
            public void foo()
            {
                Console.WriteLine("This is foo in Class Program");
            }
    
            static void fooStatic()
            {
                Console.WriteLine("This is Static foo");
            }
    
    
            static void Main(string[] args)
            {
                Program fooInstance = new Program();
    
                fooStatic();
                fooInstance.foo();
                
            }
        }
    }
