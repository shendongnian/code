    public List<TroubleTicket> GetAllTroubleTickets()
    {
        List<TroubleTicket> tickets = null;
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
