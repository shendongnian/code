    public class X : ISomeInterface
    {
        private X() { }
        public static X instance;
        public static X Instance
        {
            get
            {
                return instance ?? (instance = new X());
            }
        }
    }
