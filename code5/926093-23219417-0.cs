    public static Tuple<Node, Node> Find(Node node, string name)
    {
       return Find(node, name, null);
    }
    
    public static Tuple<Node, Node> Find(Node node, string name, Node parent)
    {
        if (node == null)
            return null;
    
        if (node.name == name)
            return new Tuple<Node, Node>(node, parent);
    
        foreach (var child in node.children)
        {
            var found = Find(child, name, node);
            if (found != null)
                return found;
        }
    
        return null;
    }
