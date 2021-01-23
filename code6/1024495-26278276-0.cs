    public List<TroubleTicket> GetAllTroubleTickets()
    {
        try
        {
            var q = _supportDeskEntities.TroubleTickets.ToList();
            return q;
        }
        catch (Exception ex)
        {
            // You can also return "new List<TroubleTicket>()" if null is an unacceptable return value
            return null;
        }
    }
