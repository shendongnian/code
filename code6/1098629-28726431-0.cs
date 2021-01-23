    public class Node<T>
    {
        public Node(T value, Node<T> tail)
        {
            Value = value;
            Tail = tail;
        }
        public T Value { get; private set; }
        public Node<T> Tail { get; private set; }
    }
    public static Node<int> ListElementsDivisibleBy3Recursive(Node<int> node)
    {
        if (node == null)
            return node;
        else if (node.Value % 3 == 0)
            return new Node<int>(node.Value, ListElementsDivisibleBy3Recursive(node.Tail));
        else
            return ListElementsDivisibleBy3Recursive(node.Tail);
    }
