    public String PrintNodes(string a)
    {
        string Output = "";
    
        Node theNode = Find(a);
    
        if (Node != null)
        {
            Output += "Node: " + theNode.data;
        }
        else
        {
            Output += "There is no node " + a;
        }
    
    
        return Output;
    }
