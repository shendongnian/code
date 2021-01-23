    public class Node<T>
    {
        public Node(T value, IEnumerable<Node<T>> children)
        {
            Value = value;
            Children = children;
        }
        public T Value { get; private set; }
        public IEnumerable<Node<T>> Children { get; private set; }
    }
