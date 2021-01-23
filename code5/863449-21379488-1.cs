    public class ConstrainedStack<T> : IEnumerable<T>, ICollection, IEnumerable
    {
        private readonly int maxSize;
        public ConstrainedStack(int maxSize)
        {
            this.maxSize = maxSize;
        }
        private Stack<T> stack=new Stack<T>();
        //the magic bit. (deviates from Stack<T> API
        //by returning true or false in case of success or failure)
        public bool Push(T item)
        {
            if(stack.Count<maxSize)
            {
                stack.Push(item);
                return true;
            }
            return false;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) stack).GetEnumerator();
        }
        public void CopyTo(Array array, int index)
        {
            ((ICollection) stack).CopyTo(array, index);
        }
        public object SyncRoot
        {
            get { return ((ICollection) stack).SyncRoot; }
        }
        public void Clear()
        {
            stack.Clear();
        }
        public bool IsSynchronized
        {
            get { return ((ICollection) stack).IsSynchronized; }
        }
        public bool Contains(T item)
        {
            return stack.Contains(item);
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            stack.CopyTo(array, arrayIndex);
        }
        public Stack<T>.Enumerator GetEnumerator()
        {
            return stack.GetEnumerator();
        }
        public void TrimExcess()
        {
            stack.TrimExcess();
        }
        public T Peek()
        {
            return stack.Peek();
        }
        public T Pop()
        {
            return stack.Pop();
        }
        public T[] ToArray()
        {
            return stack.ToArray();
        }
        public int Count
        {
            get { return stack.Count; }
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return stack.GetEnumerator();
        }
    }
