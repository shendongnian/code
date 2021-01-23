    public class MStack<T> : IEnumerable<T>
    {
        private readonly Dictionary<int, T> stack = new Dictionary<int, T>();
        public void Push(T item)
        {
            stack.Add(stack.Count, item);
        }
        public T Pop()
        {
            var item = Peek();
            stack.Remove(stack.Count - 1);
            return item;
        }
        public T Peek()
        {
            return stack[stack.Count - 1];
        }
        public int Count { get { return stack.Count; } }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < stack.Count; i++)
                yield return Peek();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
