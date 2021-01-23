    using System;
    class D
    {    
        public event Action eventEH;
        public void someMethod()
        {    
            EventHandler objEH = eventEH;
            if (objEH != null)
                objEH();
        }
    }
    
    class B
    {
        public B(D objD)
            { objD.eventEH += display; }
    
        void display()
            { Console.WriteLine("display"); }
    }
    
    class A
    {
        static int Main()
        {
            D objD = new D();
            B objB = new B(objD);
            objD.someMethod();        
            return 0;
        }
    }
