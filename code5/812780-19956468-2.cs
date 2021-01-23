    class UniqueQueue<T>
    {
        private readonly Queue<T> queue = new Queue<T>();
        private HashSet<T> alreadyAdded = new HashSet<T>();
        public virtual void Enqueue(T item)
        {
            if (alreadyAdded.Add(item)) { queue.Enqueue(item); }
        }
        public int Count { get { return queue.Count; } }
        public virtual T Dequeue()
        {
            T item = queue.Dequeue();
            return item;
        }
    }
