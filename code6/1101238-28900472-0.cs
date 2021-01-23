    /// <summary>
    /// Fixed-size buffer. When the buffer is full adding a new item removes the first item,
    /// so buffer stores the last N (where N is a size) adding items.
    /// Reading is provided by indexing, rewriting isn't allowed.
    /// Buffer could be changed by using method Add only.
    /// </summary>
    public class RingBuffer<T> {
        int size;
        T[] ringbuffer;
        int i0 = 0, count = 0;
        int getIndex(int i) {
            int k=i0+i;
            return k < count ? k : k-size;
        }
        public RingBuffer(int size) {
            this.size = size;
            ringbuffer = new T[size];
        }
        public int Count {
            get { return count; }
        }
        public bool isFull {
            get { return count == size; }
        }
        public T this[int i] {
            get { return ringbuffer[getIndex(i)]; }
        }
        public void Add(T item) {
            if (isFull)
                // rewrite the first item
                ringbuffer[i0++] = item;
            else
                ringbuffer[count++] = item;
        }
    }
