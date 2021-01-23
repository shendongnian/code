    class A {
        public virtual void CompareSomeData(A instanceOfA) { }
    }
    
    class B : A {        
        public void CompareSomeData(B instanceOfB) {
            // ...
        }
        public override void CompareSomeData(A instanceOfA) {
            // ...
        }
    }
