    public List<TroubleTicket> GetAllTroubleTickets()
    {
        List<TroubleTicket> tickets;
        try
        {
            tickets = _supportDeskEntities.TroubleTickets.ToList();
        }
        catch (Exception ex)
        {
            // You can also use "new List<TroubleTicket>()" if null is an unacceptable return value
            tickets = null;
        }
        return tickets;
    }
