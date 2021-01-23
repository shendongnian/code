    [AttributeUsage(AttributeTargets.Method)]
    public class FooAttribute : Attribute
    {
        public FooAttribute(params string[] values)
        {
            ...
        }
    }
    
    [Foo("a", "b")]
    static void SomeMethod()
    {
    }
