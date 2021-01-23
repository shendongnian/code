    public class TicketEfRepository: ITicketRepository
    {
        public IList<Ticket> FindAll()
        {
           var db = new TicketDBContext();
           return db.Tickets.ToList();
        }
        public Ticket Find(int id)
        {
           var db = new TicketDBContext();
           return db.Tickets.Find(id);
        }
        ...    
