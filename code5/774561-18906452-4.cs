    public interface ITicketRepository
    {
        IList<Ticket> FindAll();
        Ticket Find(int id);
        void Save(Ticket ticket);
    }
