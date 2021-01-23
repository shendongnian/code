    /* Here is a simple program of Deep copy. This will help you to fully understand ICloneable Interface.
    
    using System;
    
    namespace ICloneableDemo
    {
    
        class Program
        {
            class Demo : ICloneable
            {
    
                public int a, b;
                public Demo(int x, int y)
                {
                    a = x;
                    b = y;
                }
    
                public override string ToString()
                {
                    return string.Format(" a : " + a + "  b: " + b);
                }
    
    
                public object Clone()
                {
                    Demo d = new Demo(a, b);
                    return d;
                }
            }
    
    
            static void Main(string[] args)
            {
    
                Demo d1 = new Demo(10, 20);
                Console.WriteLine(" d1 : "+d1);
    
                Demo d2 = (Demo)d1.Clone();
                Console.WriteLine(" d2 : " + d2);
    
                Demo d3 = (Demo)d2.Clone();
                Console.WriteLine(" d3 : " + d3);
    
                Console.WriteLine("Changing the value of d1");
    
                d1.a = 44; 
                d1.b = 33;
    
       
                Console.WriteLine(" d1 : " + d1);
    
                Console.WriteLine(" d2 : " + d2);
    
                Console.WriteLine(" d3 : " + d3);
    
    
                Console.WriteLine("Changing the value of d3");
    
                d3.a = 50;
                d3.b = 60;
    
                Console.WriteLine(" d1 : " + d1);
    
                Console.WriteLine(" d2 : " + d2);
    
                Console.WriteLine(" d3 : " + d3);
    
    
                Console.ReadKey();
            }
        }
    }
    
    /*Output:
     d1 :  a : 10  b: 20
     d2 :  a : 10  b: 20
     d3 :  a : 10  b: 20
    Changing the value of d1
     d1 :  a : 44  b: 33
     d2 :  a : 10  b: 20
     d3 :  a : 10  b: 20
    Changing the value of d3
     d1 :  a : 44  b: 33
     d2 :  a : 10  b: 20
     d3 :  a : 50  b: 60
    */
