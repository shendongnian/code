    public class OnRequestProducerConsumerQueue<T>
    {
        private Queue<T> m_Items = new Queue<T>();
        private object m_lock = new Object();
        private Int32 m_NeedItems = 0;
        public void EnqueueIfRequired(T value)
        {
            lock (this.m_lock)
            {
                if (this.m_NeedItems == 0)
                    return;
                this.m_Items.Enqueue(value);
                this.m_NeedItems--;
                Monitor.PulseAll(this.m_lock);
            }
        }
        public T Dequeue()
        {
            lock (this.m_lock)
            {
                this.m_NeedItems++;
                while (this.m_Items.Count < 1)
                {
                    Monitor.Wait(this.m_lock);
                }
                return this.m_Items.Dequeue();
            }
        }
    }
