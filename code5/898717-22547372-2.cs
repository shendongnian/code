    using System;
    
    
    namespace TestLib
    {
        public class MC
        {
            public double method1(int n)
            {
                Console.WriteLine("Executing method1");
                return 42.0;
                /* .. */
            }
    
            public double method2(Delegate f)
            {
                Console.WriteLine("Executing method2");
                f.DynamicInvoke();
                Console.WriteLine("Done executing method2");
                return 24.0;
                
            }
        }
    }
