    public string RemoveNode(object n)//remove nodes
    {
        String Output = "";
        if (head == null)
        {
            Output += "\r\nLink list is empty";
        }
        else
        {
            var toRemove = FindNode(n);
            if (toRemove == null)
            {
                Output += "Node not found in Doubly Linked List\r\n";
            }
            else
            {                   
                if(toRemove.prev != null)
                    toRemove.prev.next = toRemove.next != null ? toRemove.Next : null;
                if(toRemove.next != null)
                    toRemove.next.prev = toRemove.prev != null ? toRemove.prev : null;
                Output += "Node removed from Doubly Linked List\r\n";
            }
        }
        return Output; 
    }
