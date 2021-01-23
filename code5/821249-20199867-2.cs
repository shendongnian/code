    class MyLibClassDefaultDecoratorBase : ILibInterface
    {
        protected LibClass backingObject;
        public MyLibClassDefaultDecoratorBase(LibClass obj)
        {
            this.backingObject = obj;
        }
        // have them all here
        public method1() { return this.backingObject.method1(); }
        public method2() { return this.backingObject.method2(); }
        //...
    }
