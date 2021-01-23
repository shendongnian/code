     public class Test
    {
        public Node getTree()
        {
            Node output = new Node();   // create tree root
            // create child nodes
            output.LEFT = new Node();
            output.RIGHT = new Node(); 
            //set TAL values
            output.TAL = 2;
            output.LEFT.TAL = 1;
            output.RIGHT.TAL = 3;
            //return tree
            return output;
        }
        public class Node
        {
            public int TAL;
            public Node LEFT;
            public Node RIGHT;
    
        }
    
    }
