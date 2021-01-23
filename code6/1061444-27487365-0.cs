    class Foo
    {
        Bar b1 = new Bar(this);
    
        public object MethodToCall(){ /*Method body here*/ }
    }
    
    Class Bar
    {
        private readonly Foo foo;
        public Bar(Foo foo) {
            // Save a reference to Foo so that we could use it later
            this.foo = foo;
        }
    
        public void MethodCaller()
        {
            // Now that we have a reference to Foo, we can use it to make a call
            foo.MethodToCall();
        }
    }
