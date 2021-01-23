      public void PrintAll()
        {
            var stack = new Stack<TicketNode>();
            TicketNode cur = first;
            while (cur != null)
            {
                stack.Push(cur);
                cur = cur.next;
            }
    		
    		while (stack.Count > 0)
    		    stack.Pop().data.PrintDescription();
        }
