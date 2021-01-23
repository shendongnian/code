    class SearchResult {
     public Node Found;
     public Node Parent;
    }
    public static SearchResult Find(Node node, string name)
    {
    
        if (node == null)
            return null;
    
        if (node.name == name)
            return new SearchResult { Found =  node, Parent = null};
    
        foreach (var child in node.children)
        {
            var found = Find(child, name);
            if (found != null)
                        return new SearchResult { Found =  found, Parent = node};
        }
    
        return null;
    }
