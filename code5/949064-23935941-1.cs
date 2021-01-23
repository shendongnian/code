    class A {
        public bool CompareSomeData(A instanceOfA) {
            return CompareSomeDataImpl(instanceOfA);
        }
    
        protected virtual bool CompareSomeDataImpl(A instanceOfA)
        { return true; }
    }
    
    class B : A {
        public new string CompareSomeData(A instanceOfA) {
            // ...
        }
        protected override bool CompareSomeDataImpl(A instanceOfA) {
            // ...
        }
    }
