    internal static class FooHelper
    {
        private static class DefaultData<T>
        {
            public static T Value = default(T);
        }
        static FooHelper()
        {
            DefaultData<int>.Value = 42;
            DefaultData<string>.Value = "Hello World";
        }
        // From @JeffreyZhao:
        //
        // Use a static method to trigger the static constructor automatically,
        // or we need to use RuntimeHelpers.RunClassConstructor to make sure
        // DefaultData is corrected initialized.
        //
        // The usage of RuntimeHelpers.RunClassConstructor is kept but commented.
        // Using GetDefault<T>() is a better approach since static Foo() would be
        // called multiple times for different generic arguments (although there's 
        // no side affect in this case).
        //
        // Thanks to @mikez for the suggestion.
        public T GetDefault<T>()
        {
            return DefaultData<T>.Value;
        }
    }
    public class Foo<T>
    {
        /* See the comments above.
        static Foo()
        {
            RuntimeHelpers.RunClassConstructor(typeof(FooHelper).TypeHandle);
        }
         */
        public T Data { get; protected set }
        public Foo()
        {
            Data = FooHelper.GetDefault<T>();
        }
    }
