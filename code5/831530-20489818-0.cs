    class A
    {
        public int Field {get; private set;}
    }
    class A
    {
        int _field;
        public int Field
        {
            get { return _field; }
            private set {_field = value; }
        }
    }
