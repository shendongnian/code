    public static HelpDeskTicket GetTicketInfo(int ticketId, DbDataContext dc)
    {
        private DateTime _default = new DateTime(1900, 1, 1);
    
        return GetInfo(ticketId, dc, _default).SingleOrDefault();
    }
