    public class Root
    {
        private readonly A _a;
    
        public Root(A a)
        {
            if (a == null) throw new ArgumentNullException("a");
            _a = a;
        }
    }
    
    public class A
    {
        private readonly B _b;
    
        public A(B b)
        {
            if (b == null) throw new ArgumentNullException("b");
            _b = b;
        }
    }
    
    public class B
    {
        private readonly C _c;
    
        public B(C c)
        {
            if (c == null) throw new ArgumentNullException("c");
            _c = c;
        }
    }
    
    public class C
    {
        
    }
