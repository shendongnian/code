    public enum Foo
    {
        Bar
    }
    
    public static class FooExtensions
    {
        public static string GetDescription(this Foo @this)
        {
            switch (@this)
            {
                case Foo.Bar:
                    return "A bar";
            }
        }
    }
    // consuming code
    var foo = Foo.Bar;
    var description = foo.GetDescription();
