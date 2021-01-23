    public object Pop()
    {
        if (StackEmpty())
        {
            throw new Exception("Error: No nodes to pop from stack");
        }
        object RemoveItem = headNode.Data; 
        if (headNode == tailNode)
        {
            headNode = tailNode = null;
        }
        else
        {
            headNode = headNode.Next;
        }
        nbElements--;  
        return RemoveItem;        
    }
