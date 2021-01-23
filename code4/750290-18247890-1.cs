    public class Sample<TFoo>
    {
        static void Test()
        {
            Func<TFoo, TFoo> identity = Helpers.Identity<TFoo>();
        }
    }
