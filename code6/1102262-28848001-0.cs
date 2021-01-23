    Project A
    namespace A {
            public class Hello : A1{
                public Hello(IWorld world){
                    w.run(this);
                }
        }
    }
    Project B
    namespace B {
        public class World : IWorld {
            public run(A1 a1){
                ...
            }
        }
    }
    Project I
    namespace I {
        public interace A1{}
        public interface IWorld { run(A1); }
    }
    project Comp
    namespace Comp {
        public class AppEntry {
            IWorld w = new World();
            A1 a1 = new Hello(w);
        }
    }
