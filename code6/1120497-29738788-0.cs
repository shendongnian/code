    public string returnTicket(string supportRef)
    {
       try
       {
           string ticket = DAL.data.GetTicket(supportRef);
           return ticket;
       }
       catch (Exception ex)
       {
           throw ex;
       }
    }
