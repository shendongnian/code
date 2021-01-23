    class A {
        public A (string m) {}
    }
    class B : A{
        public B (string m) : base (m) {}
    }
    class C : B {
        public C (string m) : base (m) {}
    }
