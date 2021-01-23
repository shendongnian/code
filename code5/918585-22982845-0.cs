    public class Test
    {
        public Node getTree()
        {
            // Create the nodes
            Node parent = new Node();
            Node right = new Node();
            Node left = new Node();
            // Link them
            parent.LEFT = left;
            parent.RIGHT = right;
            // Populate their values
            parent.TAL = 2;
            right.TAL = 3;
            left.TAL = 1;
            // Return the tree
            return parent;
        }
        public class Node
        {
            public int TAL;
            public Node LEFT;
            public Node RIGHT;
        }
    }
