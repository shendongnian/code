    public class Host<T>
    {
        private readonly IHelper<T> helper;
    
        public Host(IHelper<T> helper)
        {
            this.helper = helper;
        }
    
        public void Add(T item)
        {
            // Do something
            this.helper.AddOrUpdate(item);
            // Do something else
        }
    
        public void Update(T item)
        {
            // Do something
            this.helper.AddOrUpdate(item);
            // Do something else
        }
    }
