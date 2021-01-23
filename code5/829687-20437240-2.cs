    public class ViewModel()
    {
        public static ViewModel Instance;
        public ViewModel()
        {
            Instance = this;
        }
        public string foo = "bar";
    }
