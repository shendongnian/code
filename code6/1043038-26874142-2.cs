    public void AddFirst(int item)
    {
       Node newNode = new Node();
       newNode.value = item;
       
       newNode.next = start;
       start = newNode;
    }
