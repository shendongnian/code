    public class Foo
    {
        private static readonly Lazy<Foo> Instance = new Lazy<Foo>(() => new Foo());
        
        private Foo()
        {
        }
        
        public static Foo Default
        {
            get
            {
                return Instance.Value;
            }
        }
        
        public static int[] Bar { get; set; }
    }
