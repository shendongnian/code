    public class FooClass {
        private int _x;
        public int X {
            get {
                return _x;
            }
            set {
                _x = value;
                Debugger.Break();
            }
        }
    }
