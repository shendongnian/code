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
    public void Insert(int index, int val)
    {
       // COMPLETELY UNTESTED BUT MAY POINT YOU IN THE RIGHT DIRECTION
       Node newNode = new Node();
       newNode.value = val;
       
       if (head == null) { return; }
       
       Node node = new Node();
       if (index == 0){
          newNode.Next = head;
          head = newNode;
       } 
       node = head;
       
       while(node.Head!=null && index > 1)
       {
          node = node.Next;
          index--;
       }
       if (node != null && index >= 0){
          var next = node.Next;
          newNode.Next = next;
          node.Next = newNode;
       }
       size++;
    }
