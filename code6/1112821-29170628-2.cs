    public static class ParameterUtilities
    {
        public static void AssignValue<TFactory, T>(this IParameter<TFactory, T> prm, string str)
            where TFactory : new(), IFactory<T>
        {
            var factory = new TFactory();
            prm.Value = factory.Create(str);
        }
    }
