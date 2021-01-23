    public class Dog
    {
        static int counter = 0;
        public string Breed { get; set; }
        public Dog()
        {
            Interlocked.Increment(ref counter);
        }
        ~Dog()
        {
            Interlocked.Decrement(ref counter);
        }
    }
