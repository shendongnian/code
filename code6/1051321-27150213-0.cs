    class Foo
    {
        public dynamic Value { get; private set; }
        public Foo( string value )
        {
            this.Value = value;
        }
        public Foo( bool value )
        {
            this.Value = value;
        }
    }
