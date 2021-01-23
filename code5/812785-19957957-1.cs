    sealed class UniqueQueue<T> : IEnumerable<T>, ICollection, IEnumerable
    {
        private readonly Queue<T> queue;
        private readonly HashSet<T> alreadyAdded;
        public UniqueQueue(IEqualityComparer<T> comparer)
        {
            queue = new Queue<T>();
            alreadyAdded = new HashSet<T>(comparer);
        }
        public UniqueQueue(IEnumerable<T> collection, IEqualityComparer<T> comparer)
        {
            //Do this so the enumeration does not happen twice in case the enumerator behaves differently each enumeration.
            var localCopy = collection.ToList();
            queue = new Queue<T>(localCopy);
            alreadyAdded = new HashSet<T>(localCopy, comparer);
        }
        public UniqueQueue(int capacity, IEqualityComparer<T> comparer)
        {
            queue = new Queue<T>(capacity);
            alreadyAdded = new HashSet<T>(comparer);
        }
        //Here are the constructors that use the default comparer. By passing null in for the comparer it will just use the default one for the type.
        public UniqueQueue() : this((IEqualityComparer<T>) null) { }
        public UniqueQueue(IEnumerable<T> collection) : this(collection, null) { }
        public UniqueQueue(int capacity) : this(capacity, null) { }
        /// <summary>
        /// Attempts to enqueue a object, returns false if the object was ever added to the queue in the past.
        /// </summary>
        /// <param name="item">The item to enqueue</param>
        /// <returns>True if the object was successfully added, false if it was not</returns>
        public bool Enqueue(T item)
        {
            if (!alreadyAdded.Add(item))
                return false;
            queue.Enqueue(item);
            return true;
        }
        public int Count
        {
            get { return queue.Count; }
        }
        public T Dequeue()
        {
            return queue.Dequeue();
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return ((IEnumerable<T>)queue).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)queue).GetEnumerator();
        }
        void ICollection.CopyTo(Array array, int index)
        {
            ((ICollection)queue).CopyTo(array, index);
        }
        bool ICollection.IsSynchronized
        {
            get { return ((ICollection)queue).IsSynchronized; }
        }
        object ICollection.SyncRoot
        {
            get { return ((ICollection)queue).SyncRoot; }
        }
    }
