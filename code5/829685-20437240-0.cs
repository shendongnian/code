    public class ViewModel()
    {
        public static ViewModel Instance;
        public ViewModel()
        {
            Instance = this;
        }
        private string foo = "bar";
    }
