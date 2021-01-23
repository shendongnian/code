    public class A 
    {
        public int Prop1;
        public int Prop2;
        public int Prop3;
        public int Prop4;
        public int Prop5;
        public A()
        {
        }
        public A(A a)
        {
            this.Prop1 = a.Prop1;
            this.Prop2 = a.Prop2;
            this.Prop3 = a.Prop3;
            this.Prop4 = a.Prop4;
            this.Prop5 = a.Prop5;
        }
    }
    public class B:A
    {
        public int PropB1;
        public int PropB2;
        
        public B(A a) : base(a)
        {
        }
    }
    public class C:A
    {
        public int PropC1;
        public C(A a) : base(a)
        {
        }
    }
