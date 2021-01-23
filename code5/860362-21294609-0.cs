    interface IVisitor
    {
        void Visit(B b);
        void Visit<T>(C<T> c);
    }
    class A 
    {
        public virtual void Accept(IVisitor v)
        { } // Do nothing
    }
    class B : A
    {
        public override void Accept(IVisitor v)
        { v.Visit(this); }
    }
    class C<T> : B 
    {
        public override void Accept(IVisitor v)
        { v.Visit<T>(this); }
    }
    class P
    {
        class Visitor : IVisitor
        {
            public void Visit(B b) { bar(b); }
            public void Visit<T>(C<T> c) { bar<T>(c); }
        }
        public static bar(B b) { }
        public static bar<T>(C<T> c) { }
        public static void foo(A a)
        {
            a.Accept(new Visitor());
        }
    }
