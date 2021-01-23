     public class Test
    {
        public Node getTree()
        {
            //creates root node with TAL=2 using Node(int) constructor
            Node output = new Node(2);
            //creates left and right child nodes
            output.LEFT = new Node(1);
            output.RIGHT = new Node(3);
            return output;
        }
        public class Node
        {
            public int TAL;
            public Node LEFT;
            public Node RIGHT;
            //Node constructor that set TAL field
            public Node(int tal)    
            {
                  TAL = tal;
            }
        }
    
    }
