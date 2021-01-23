    public class SegmentedQueue<T> : IEnumerable<T>
    {
        private readonly LinkedList<Queue<T>> _list = new LinkedList<Queue<T>>();
        private const int SEGMENT_SIZE = 32;
        public int Count => _list.Sum(q => q.Count);
        public bool IsEmpty => _list.First == null || _list.First.Value.Count == 0;
        public void Enqueue(T item)
        {
            if (_list.Last == null || _list.Last.Value.Count == SEGMENT_SIZE)
            {
                _list.AddLast(new Queue<T>(SEGMENT_SIZE));
            }
            _list.Last.Value.Enqueue(item);
        }
        public T Dequeue()
        {
            if (this.IsEmpty)
                throw new InvalidOperationException("The Queue is empty");
            var item = _list.First.Value.Dequeue();
            if (_list.First.Value.Count == 0)
            {
                _list.RemoveFirst();
            }
            return item;
        }
        public void Clear() => _list.Clear();
        public IEnumerator<T> GetEnumerator() => _list.SelectMany(q => q)
            .GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
