    public List<TroubleTicket> GetAllTroubleTickets()
    {
        try
        {
    
            List<TroubleTicket> tickets = new List<TroubleTicket>();
    
    
            var q = _supportDeskEntities.TroubleTickets.ToList();
            return q;
        }
    
         catch (Exception ex)
        {
           return new List<TroubleTicket>(); // This is just in case you want to ignore any exceptions
    
        }
    
    
    }
