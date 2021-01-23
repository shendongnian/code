    public abstract class A { }
    public class B : A
    {
        private static Lazy<B> _instance = new Lazy<B>(() => new B());
        private B() { }
        public static B Instance
        {
            get
            {
                return _instance.Value;
            }
        }
    }
