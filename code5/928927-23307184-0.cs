    void AddTicket(Ticket t)
    {
        TicketNode ticNode; //creates a new node
        
        if (first == null) //for kick-starting the list
            first = new TicketNode(t);
        else
        {
            ticNodeNew = new TicketNode(t);
			TicketNode ticNode; = first;
			while(ticNode.next != null)
			{
				ticNode = ticNode.next;
			}
            
			ticNode.next = ticNodeNew;
        } 
    }
}
