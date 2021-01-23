    public void Add(int val)
    {
       Node newNode = new Node();
       newNode.value = val;
       if (head == null)
       {
           head = newNode;
           current = newNode;
       }
       else
       {
           current.Next = newNode;
           current = newNode;
       }
       size++;
    }
