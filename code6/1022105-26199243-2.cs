        interface IA {
            void F();
        }     
    }
    namespace Context1 {
        partial class A : IA {
            private Common.A _a = new Common.A("context1");
            public void F(){return _a.F();}
        }
    }
    namespace Context2 {
        partial class A : IA {
            private Common.A _a = new Common.A("context2");
            public void F(){return _a.F();}
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
