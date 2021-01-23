    using System;
    using System.Collections.Generic;
    
    abstract class A
    {
        public abstract dynamic Val { get;   set; }
    
    }
    class B : A
    {
        public override dynamic Val { get;  set; }
    }
    class C : A
    {
        public override dynamic Val { get;  set; }
    }
    class D : A
    {
        public override dynamic Val { get;  set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<A> { new B(), new C(), new D() };
            // ... 
    
            foreach (A item in list)
            {
                Console.WriteLine(String.Format("Value is: {0}", item.Val));
            }
        }
    }
