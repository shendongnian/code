    interface IA {
        void Method();
    }
    interface IB {
        void Method();
    }
    abstract class B : IB {
        void IB.Method() { ... }
    }
    abstract class A : B, IA {
        void IA.Method() { ... }
    }
    class Both : A { ... }
