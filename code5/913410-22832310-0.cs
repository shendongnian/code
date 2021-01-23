    class Tree<T>
    {
        Node<T> PrimaryNode;
        public void SetPrimaryNode(T obj){
            Node<T> node = new Node<T>();
            node.setObject(obj);
            this.PrimaryNode = node;
        }
        public void SetPrimaryNode(Node<T> node)
        {
            this.PrimaryNode = node;
        }
        public Node<T> GetPrimaryNode()
        {
            return PrimaryNode;
        }
    }
