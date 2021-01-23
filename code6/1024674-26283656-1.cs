    public class MyViewModel
    {
        public string SomeValue { get; private set; }
        public async Task Initialize()
        {
            SomeValue = await GetTheValue();
        }
    }
