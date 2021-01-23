    public List<TroubleTicket> GetAllTroubleTickets()
    {
        List<TroubleTicket> tickets = new List<TroubleTicket>();
        bool gotTickets = true;
        try{
            tickets = _supportDeskEntities.TroubleTickets.ToList();
        }
        catch (SpecificException ex){ 
            gotTickets = false;
        }
        catch (Exception ex){ // catches all other "unexpected" exceptions
            // log and/or...
            throw;
        }
        return gotTickets ? tickets : null;
    }
