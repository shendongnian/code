    public class Repeater<T> : IEnumerator<T>
    {
        private int count;
        private T element;
        public Repeater(T element, int count)
        {
            this.element = element;
            this.count = count;
        }
        public T Current { get { return element; } }
        object IEnumerator.Current
        {
            get { return Current; }
        }
        public void Dispose() { }
        public bool MoveNext()
        {
            if (count > 0)
            {
                count--;
                return true;
            }
            else
                return false;
        }
        public void Reset()
        {
            throw new NotSupportedException();
        }
    }
