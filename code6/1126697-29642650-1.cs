    public class CustomQueue<T>
    {
        private readonly Queue<T> queue;
            
        private int _capacity;
        public int Capacity
        {
            get { return _capacity; }
            set { _capacity = value; }
        }
    
    
        public CustomQueue()
        {
            this.queue = new Queue<T>();
        }
            
        public CustomQueue(int capacity)
        {
            this.Capacity = capacity;
            this.queue = new Queue<T>(capacity);
        }
    
        public void Enqueue(T element)
        {
            if (this.queue.Count == this.Capacity)
            {
                IncreaseCapacity();
            }
                
            this.queue.Enqueue(element);
        }
    
        public T Dequeue()
        {
            if (this.queue.Count < 1)
            {
                throw new InvalidOperationException("Error: Queue is empty");
            }
    
            return this.queue.Dequeue();
        }
    
        public T Peek()
        {
            if (this.queue.Count < 1)
            {
                throw new InvalidOperationException("Error: Queue is empty");
            }
    
            return this.queue.Peek();
        }
    
        public T Min()
        {
            bool notSupport = false;
            try
            {
                T minItem = this.queue.Peek();
    
                foreach (T temp in this.queue)
                {
                    try
                    {
                        if (Convert.ToDouble(minItem) > Convert.ToDouble(temp))
                            minItem = temp;
                    }
                    catch
                    {
                        notSupport = true;
    
                    }
                }
                return minItem;
            }
            catch
            {
                if (notSupport)
                    throw (new InvalidOperationException("Error: Method not support this type."));
                else
                    throw (new InvalidOperationException("Error: Queue is empty"));
            }
        }
    
        public void Display()
        {
            foreach (T item in this.queue)
            {
                Console.Write(item);
                Console.Write("-->");
            }
            Console.WriteLine();
        }
    
    
        protected void IncreaseCapacity()
        {
            this.Capacity++;
        }
    }
