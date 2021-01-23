    public class X : ISomeInterface
    {
        private X() { }
        public static Lazy<X> instanceLazy = new Lazy<X>(() => new X());
        public static X Instance
        {
            get
            {
                return instance.Value;
            }
        }
    }
