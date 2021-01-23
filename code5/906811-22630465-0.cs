    namespace ex
    {
        public abstract class A
        {
            public delegate void foo();
            public A()
            { }
        }
    
        class B : A
        {
            private foo handler;
            public B()
            {
                handler = childfoo;
            }
            public void callHandlerHere()
            {
                handler();
            }
            public void childfoo()
            {/* Do something*/}
        }
    }
