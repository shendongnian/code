    // I.e. Re-expose by wrapping your Func in a static class:
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
    // Re-expose generic via Generic Method
    public class GenericMethod
    {
        public Func<T, T> FuncF<T>()
        {
            return MyFuncs.F;
        }
    }
    // i.e. Consume the generic and do not re-expose it
    public class SpecificClass
    {
        public Foo FuncF(Foo f)
        {
            return MyFuncs.F<Foo>(f); // <Foo> is optional - compiler can infer
        }
    }
