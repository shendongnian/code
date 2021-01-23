    public class Foo
    {
        private Foo()
        {
        }
        public static async Task<Foo> CreateAsync()
        {
            Foo foo = new Foo();
            await foo.InitializeAsync();
            return foo;
        }
    }
