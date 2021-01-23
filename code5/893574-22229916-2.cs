    public class MyProxy
    {
        private readonly Foo _foo;
        private readonly Bar _bar;
        public MyProxy(Foo foo)
        {
            this._foo = foo;
        }
        public MyProxy(Bar bar)
        {
            this._bar = bar;
        }
        public string SharedProperty1
        {
            get
            {
                if(this._foo != null)
                {
                    return this._foo.SharedProperty1;
                }
                if(this._bar != null)
                {
                    return this._bar.SharedProperty1;
                }
                throw new InvalidOperationException("Both underlying objects are null");
            }
        }
    }
