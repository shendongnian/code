    public class Node
    {
        public object NodeContent;
        public Node Next;
    }
    public class Class1
    {
        Class2 p = new Class2();
        private Node root;
        public void function1()
        {
            var tree = new Node();
            root = tree;
            p.function2(root);
        }
    }
    public class Class2
    {
        public void function2(Node root)
        {
        }
    }
