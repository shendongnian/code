    public void Add(int val)
    {
        var newNode = new Node();
        Node currentNode = head;
        int index=0;
   
        while (currentNode != null && index < val)
        {
            currentNode=currentNode.Next;
            index++;
        }
        newNode.Next = currentNode.Next;
        currentNode.Next = newNode;
        // If its a doubly linked list, you might need to update .Prev too
    }
