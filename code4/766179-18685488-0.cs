    public class Temporary<T>
    {
        private readonly Func<T> factory;
        private readonly TimeSpan lifetime;
        private readonly object valueLock = new object();
        private T value;
        private bool hasValue;
        private DateTime creationTime;
        
        public Temporary(Func<T> factory, TimeSpan lifetime)
        {
            this.factory = factory;
            this.lifetime = lifetime;
        }
        
        public T Value
        {
            get
            {
                DateTime now = DateTime.Now;
                lock (this.valueLock)
                {
                    if (this.hasValue)
                    {
                        if (this.creationTime.Add(this.lifetime) < now)
                        {
                            this.hasValue = false;
                        }
                    }
                    
                    if (!this.hasValue)
                    {
                        this.value = this.factory();
                        this.hasValue = true;
                        // You can also use the existing "now" variable here.
                        // It depends on when you want the cache time to start
                        // counting from.
                        this.creationTime = Datetime.Now;
                    }
                    
                    return this.value;
                }
            }
        }
    }
