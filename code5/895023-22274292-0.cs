    class Test
    {
        void Foo()
        {
            Expression<Func<string>> baseString = () => base.ToString();
        }
        public override string ToString()
        {
            return "overridden value";
        }
    }
