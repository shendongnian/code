    // I.e. Wrapping your Func in a static class:
    public static class MyFuncs
    {
        public static T F<T>(T arg)
        {
            return arg;
        }
    }
    public class Generics<T>
    {
        // Use it as a field
        private Func<T, T> f = MyFuncs.F;
        // Or getter func
        public Func<T, T> FuncF()
        {
            return MyFuncs.F;
        }
    }
    // ... Or Generic Method
    public class GenericMethod
    {
        public Func<T, T> FuncF<T>()
        {
            return MyFuncs.F;
        }
    }
