    class foo
    {
        public foo()
        {
        }
        public int bar = 0;
    }
    class footu : Tuple<foo, foo>
    {
        public footu()
            : base(new foo(), new foo())
        {
        }
    }
    ...
    footu ft = new footu();
    ft.Item1.bar = 0;
