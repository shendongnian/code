    public static class FooHelper
    {
        public static class DefaultData<T>
        {
            public static T Value = default(T);
        }
        static FooHelper()
        {
            DefaultValue<int>.Value = 42;
        }
    }
    public class Foo<T>
    {
        public T Data { get; protected set }
        public Foo()
        {
            Data = FooHelper.DefaultData<T>.Value;
        }
    }
