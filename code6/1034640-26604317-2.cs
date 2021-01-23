    public List<string> TicketNames()
    {
        return AllDevelopmentTickets
            .Select(t => t.id.ToString(CultureInfo.InvariantCulture))
            .ToList();
    }  
       var ticketSummary = new TicketSummary();
       var ticketNames = ticketSummary.TicketNames();
 
        foreach(var ticketName in ticketNames)
        {
            Console.WriteLine(ticketName);
        }
