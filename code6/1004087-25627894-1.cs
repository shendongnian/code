    public class Counter : IEnumerator<int>
    {
        private int remaining;
        public Counter(int start, int count)
        {
            Current = start;
            this.remaining = count;
        }
        public int Current { get; private set; }
        object IEnumerator.Current
        {
            get { return Current; }
        }
        public void Dispose() { }
        public bool MoveNext()
        {
            if (remaining > 0)
            {
                remaining--;
                Current++;
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
