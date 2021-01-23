    public class SomeBaseClass {
        private int _x;
        public int X { get { return _x; } set { _x = value; } }
    }
    public class DerivedClass : SomeBaseClass {
        void DoSomething() {
            // Does not have access to _x
        }
    }
