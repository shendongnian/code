    class A {
        public int val;
        protected virtual A CloneInternal() {
            return (A)MemberwiseClone();
        }
        public A Inc() {
            A a=CloneInternal();
            ++a.val;
            return a;
        }
    }
    class B:A {
        public new B Inc() {
            return (B)base.Inc();
        }
    }
    static void Main() {
        A a=new B();
        a=a.Inc();
        Console.WriteLine(a.GetType());
    }
