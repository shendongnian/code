    public interface IFoo
    {
        void SomeMethod(int para);
    }
    public static class FooExtensions
    {
        public static void SomeMethod(this IFoo foo)
        {
            foo.SomeMethod(0);
        }
    }
