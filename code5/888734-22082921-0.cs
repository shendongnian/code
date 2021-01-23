    enum Result {
        Found,
        NotFound,
        Aborted
    }
    public static Result DepthFirstSearch(Node node) {
        
        Stack<Node> stack = new Stack<Node>();
        stack.Push( node );
        
        while( stack.Count > 0 ) {
            
            Node n = stack.Pop();
            if( IsNodeWeWant( n ) ) return Result.Found;
            
            foreach(Node child in n.Children) stack.Push( child );
            
            if( stack.Count >= 4000 ) return Result.Aborted;
            
        }
        return Result.NotFound;
    }
