    class A {
        public A (string m) {}
    }
    class B : A {
        public B () : base ("empty") {}
    }
    class C : B {
        public C (string m) : base (m) {}
    }
