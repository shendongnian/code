    }
    namespace Context1 {
        partial class A : Common.A {
            public A () : base ("context1");
        }
    }
    namespace Context2 {
        partial class A : Common.A {
            public A () : base ("context2");
        }
    }
    class Program {
        static void Main(string[] args) {
            Context1.A a1 = new Context1.A();
            Context2.A a2 = new Context2.A();
            a1.F();
            a2.F();
            Console.ReadKey();
        }
    }
