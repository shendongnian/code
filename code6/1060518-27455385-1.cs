    class TestClass
    {
        public async Task<Foo> ExecuteAsync()
        {
            await Task.Delay(3000);
            return new Foo();
        }
        public Foo Execute()
        {
            Thread.Sleep(3000);
            return new Foo();
        }
    }
