    public interface foo
    {
        string ToString(someBase input);
        someBase FromString(string input);
    }
    public static class Bar
    {
        public static string ToString(someBase input)
        {
            if (input.GetType() == typeof(Duck))
            {
                foo duckie = new DuckHandler();
                return duckie.ToString(input);
            }
            else if (input.GetType() == typeof(DeadParrot)) { /* ..snip.. */ }
        }
        public static someBase FromString(string input, type Type) {
            if (type == typeof(Duckie))
            {
                foo duckie = new DuckHandler(input);
                return duckie;
            }
            else if (type == typeof(OKLumberjack)) { /* ..snip.. */ }
        }
    }
