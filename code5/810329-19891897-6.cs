    class ImmutableList<T>
    {
        public static readonly ImmutableList<T> Empty = new ImmutableList<T>(null, default(T));
        private ImmutableList(ImmutableList<T> tail, T head)
        {
            this.Head = head;
            this.Tail = tail;
        }
        public T Head { get; private set; }
        public ImmutableList<T> Tail { get; private set; }
        public ImmutableList<T> Push(T head)
        {
            return new ImmutableList<T>(this, head);
        }
        public IEnumerable<ImmutableList<T>> PowerSet()
        {
            if (this == Empty)
                yield return this;
            else
            {
                var powerset = Tail.PowerSet();
                foreach (var set in powerset) yield return set.Push(Head);
                foreach (var set in powerset) yield return set;
            }
        }
    }
