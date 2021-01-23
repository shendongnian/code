    // Here you define common parts applicable to all methods, or at least shared among some of them
    private static IQueryable<HelpdeskTicket> BuildBaseQuery(this IQueryable<HelpdeskTicket> query)
    {
        return query.Include("CreatedByPerson")
                    .Include("HelpdeskCategory")
                    .Include("HelpdeskPriority")
                    .Include("HelpdeskStatus");
    }
    // Here are the particular methods, they create a query, call helper methods for the common bits and add their specifics
    public static List<HelpdeskTicketModel> GetAllTickets()
    {
        List<HelpdeskTicketModel> Tickets = new List<HelpdeskTicketModel>();
        using (ItManagement_Entities db = new ItManagement_Entities())
        {
            Tickets = db.HelpdeskTickets.BuildBaseQuery()
                                        .OrderByDescending(t => t.TicketId)
                                        .ToList()
                                        .ForEach(t => Tickets.Add(HelpdeskTicketModel.Map(t)));
        }
        return Tickets;
    }
