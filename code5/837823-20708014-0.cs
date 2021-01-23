    public class BlockingQueue<T> { 
        private Queue<Cell<T>> m_queue = new Queue<Cell<T>>(); 
        public void Enqueue(T obj) { 
            Cell<T> c = new Cell<T>(obj);
            lock (m_queue) {
                m_queue.Enqueue(c); 
                Monitor.Pulse(m_queue); 
                Monitor.Wait(m_queue); 
            }
        } 
        public T Dequeue() { 
            Cell<T> c; 
            lock (m_queue) { 
                while (m_queue.Count == 0) Monitor.Wait(m_queue); 
                c = m_queue.Dequeue();
                Monitor.Pulse(m_queue); 
            } 
            return c.m_obj; 
        } 
    }
    class Cell<T> { 
        internal T m_obj; 
        internal Cell(T obj) { 
            m_obj = obj;
        } 
    }
