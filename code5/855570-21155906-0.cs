    [Interceptor(typeof(CacheInterceptor))]
    public class Foo : IFoo
    {
       [Cache]
       public int SomeMethod() { }
    }
