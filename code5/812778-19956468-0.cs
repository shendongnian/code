    class Foo<T>
    {
        private readonly Queue<T> queue = new Queue<T>();
        private List<T> alreadyAdded = new List<T>();
        public event EventHandler Changed;
        protected virtual void OnChanged()
        {
            if (Changed != null) Changed(this, EventArgs.Empty);
        }
        public virtual void Enqueue(T item)
        {
            if (alreadyAdded.Contains(item))
                return;
            queue.Enqueue(item);
            alreadyAdded.Add(item);
            OnChanged();
        }
        public int Count { get { return queue.Count; } }
        public virtual T Dequeue()
        {
            T item = queue.Dequeue();
            OnChanged();
            return item;
        }
    }
