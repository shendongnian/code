    public class MyViewModel
    {
        public string SomeValue { get; private set; }
        private MyViewModel() { }
        public static async MyViewModel Create()
        {
            return new MyViewModel
            {
                SomeValue = await GetTheValue()
            };
        }
    }
