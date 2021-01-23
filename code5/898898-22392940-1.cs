    using System;
    class D
    {    
        public event Action<C> eventEH;
        public void someMethod(C e)
        {    
            EventHandler objEH = eventEH;
            if (objEH != null)
                objEH(e);
        }
    }
    
    class C {}
    
    class B
    {
        public B(D objD)
            { objD.eventEH += display; }
    
        void display(C cObject)
            { Console.WriteLine("display"); }
    }
    
    class A
    {
        static int Main()
        {
            D objD = new D();
            B objB = new B(objD);
            C objC = new C();
            objD.someMethod(objC);        
            return 0;
        }
    }
