    namespace Test {
        static class System {
            public static Do() { }
        }
    
        class Foo {
            void foo() {
                System.Do(); // What's this?
            }
        }
    }
