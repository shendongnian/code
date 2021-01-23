    Node first = FindLowestUnprocessedNode();
    Node second = FindLowestUnprocessedNode();
    
    while(first != null && second != null)
    {
    
        Node sumNode = new Node(first, second)
        
        AddToEndOfList(sumNode);  
        
        Node first = FindLowestUnprocessedNode();
        Node second = FindLowestUnprocessedNode();
    }
