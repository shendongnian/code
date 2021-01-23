    class Foo<T>
    {
        T variable;
        string parameter;
        public Foo(Func<string, T> action)
        {
            variable = action(parameter);
        }
    }
