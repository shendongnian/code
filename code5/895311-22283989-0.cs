    public class Counting
    {
        private static readonly Lazy<Counting> InstanceField = 
                                new Lazy<Counting>(() => new Counting()); 
        public static Counting Instance // Singleton
        {
            get
            {
                return InstanceField.Value;
            }
        }
        public int Counter { get; set; }
        protected Counting()
        {
        }
    }
