    class UniqueQueue<T>
    {
        private readonly Queue<T> queue = new Queue<T>();
        private HashSet<T> alreadyAdded = new HashSet<T>();
        public virtual void Enqueue(T item)
        {
            if (alreadyAdded.Contains(item))
                return;
            queue.Enqueue(item);
            alreadyAdded.Add(item);
        }
        public int Count { get { return queue.Count; } }
        public virtual T Dequeue()
        {
            T item = queue.Dequeue();
            return item;
        }
    }
