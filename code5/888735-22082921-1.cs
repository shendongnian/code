    enum Result {
        Found,
        NotFound,
        Aborted
    }
    
    public static Result DepthFirstSearch(Node node, Int32 depth) {
        
        if( depth >= 4000 ) return Result.Aborted;
        
        if( IsNodeWeWant( node ) ) return Result.Found;
        
        foreach(Node child in node.Children) {
            Result result = DepthFirstSearch( child, depth + 1 );
            if( result != Result.NotFound ) return result; // return Found or Aborted
        }
    }
