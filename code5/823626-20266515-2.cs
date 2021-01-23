    public class QueueWrapper<T> : IQueue<T>
    {
        private Queue<T> queue; 
        public QueueWrapper()
        {
            queue = new Queue<T>();
        }
        public void Enqueue(T item)
        {
            queue.Enqueue(item);
        }
        public T Dequeue()
        {
            return queue.Dequeue();
        }
        public int Count
        {
            get
            {
                return queue.Count;
            }
        }
    }
