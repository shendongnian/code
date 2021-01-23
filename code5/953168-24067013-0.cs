    class GrandParent ()
    {
        public int A {get; protected set;}
        public int B {get; protected set;}
    
        public GrandParent (int a, int b);
        {
            A = a;
            B = b;
        }
    }
    
    class Parent : GrandParent ()
    {
        public Parent (int a, int b):base(a,b) {}
    }
    Child Class, were the problem occurs.
    
    class Child : Parent ()
    {
        public int C {get; protected set}
    
        public Child (int a, int b, int c):base(a,b)
        {
            C = c;
        }
    }
