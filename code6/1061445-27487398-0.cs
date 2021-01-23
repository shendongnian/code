        public Foo() { /*Constructor here*/ }
        Bar b1 = new Bar();
    
        public object MethodToCall(){ /*Method body here*/ }
    }
    
    Class Bar
    {
        public Bar() { /*Constructor here*/ }
        Foo f1 = new Foo();
        public void MethodCaller()
        {
            f1.MethodToCall();
        }
    }
