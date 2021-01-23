    int parsedTicket;
    if (int.TryParse(listEvent[0].EventTicketID, out parsedTicket))
    {
       //Value is held in parsedTicket
    }
    else
    {
       //Ticket was not a number, parsedTicket is 0.
    }
