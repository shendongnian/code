    var tickets = new TicketSummary();
    // add some tickets to tickets.AllDevelopmentTickets here...
    var ticketNames = tickets.AllDevelopmentTickets.Select(ticket => ticket.id.ToString();
    // Yes, you should probably use an UI culture in the ToString call. 
    // I'm just trying to limit my line width =)
