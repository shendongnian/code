    public List<TroubleTicket> GetAllTroubleTickets()
    {
        List<TroubleTicket> tickets =null;
        try
        {
            tickets = new List<TroubleTicket>();
            var q = _supportDeskEntities.TroubleTickets.ToList();
            return q;
        }
    
        catch (Exception ex)
        {
           //Log or handle your error
        }
    
        return tickets;
    }
