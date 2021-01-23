    static class NumericHelper<T>
    {
        public static T Zero { get; private set; }
        public static T One { get; private set; }
        static NumericHelper()
        {
            Zero = default(T);
            One = Expression.Lambda<Func<T>>(
                    Expression.Convert(
                        Expression.Constant(1),
                        typeof(T)
                    )
                  ).Compile()();
        }
    }
