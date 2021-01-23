    /// <summary>
    /// A generic first in first out data structure with access to last element.
    /// </summary>
    /// <typeparam name="T">The specific data type for this queue.</typeparam>
    public class MyQueue<T>
    {
        #region Varibles
        private Queue<T> _inner;
        private T _last;
        #endregion
    
        #region Properties
    
        /// <summary>
        /// Number of elements of this Queue.
        /// </summary>
        public int Count
        {
            get
            {
                return _inner.Count;
            }
        }
    
        /// <summary>
        /// The inner Queue in this structure.
        /// </summary>
        public Queue<T> Inner
        {
            get
            {
                return _inner;
            }
        }
    
        #endregion
    
        public MyQueue()
        {
            _inner = new Queue<T>();
        }
    
        #region Methods
        /// <summary>
        /// Adds an object to the end of the queue.
        /// </summary>
        /// <param name="item">Specific item for add.</param>
        public void Enqueue(T item)
        {
            _inner.Enqueue(item);
            _last = item;
        }
    
        /// <summary>
        /// Return and removes the first item in the queue.
        /// </summary>
        /// <returns>The first item in queue.</returns>
        /// <exception cref="InvalidOperationException">InvalidOperationException</exception>
        public T Dequeue()
        {
            if (_inner.Count > 0)
                return _inner.Dequeue();
            else
                throw new InvalidOperationException("The Queue is empty.");
        }
    
        /// <summary>
        /// Returns the first item in the queue without removing it.
        /// </summary>
        /// <returns>The first item in the queue.</returns>
        public T Peek()
        {
            return _inner.Peek();
        }
    
        /// <summary>
        /// Returns the last item in the queue without removing it.
        /// </summary>
        /// <returns>The last item in the queue.</returns>
        public T Last()
        {
            return _last;
        }
    
        /// <summary>
        /// Clears all items in the queue.
        /// </summary>
        public void Clear()
        {
            _inner.Clear();
        }
        #endregion
    }
