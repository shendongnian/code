    using System;
    
    namespace MyNS
    {
        public class MyClass
        {
            public void myFunc1(int in1, int in2, out int out1, out int out2)
            {
                out1 = in1 * in2;
                out2 = in1 + in2;    
            }
    
            public static void myFunc2(int in1, int in2, out int out1, out int out2)
            {
                out1 = in1 * in2;
                out2 = in1 + in2;    
            }
        }
    }
