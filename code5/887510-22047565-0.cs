    class BinaryTree<T> where T: IComparable<T> {
        private Node root;
        // ....
        // The public Add interface (might be different for you)
        public void Add(T value) {
            if (this.root == null) {
                // Handle the special empty case
                this.root = new Node() { Value = value };
            } 
            else {
                // Just call the private one with the right values
                this.Add(this.root, new Node() { Value = value });
            }
        }
        // This is where the recursive magic happens
        private void Add(Node current, Node toAdd) {
            // This one comes next...
        }
        class Node {
            public T Value;
            public Node Left;
            public Node Right;
        }
    }
