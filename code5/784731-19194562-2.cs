    public class Node<T>
    {
        public Node(T value, IEnumerable<Node<T>> children)
        {
            Value = value;
            Children = children.ToList();
        }
        public T Value
        {
            get;
            private set;
        }
        public List<Node<T>> Children
        {
            get;
            private set;
        }
    }
