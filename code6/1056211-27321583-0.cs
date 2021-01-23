    public enum TicketType
    {
        Adult,
        Child,
        Family
    }
    public class Booking : ITicket
    {
        private const int LIMIT = 6;
        public Show show;
        private int bookingID;
        public List<ITicket> tickets;
        
        public int BookingID
        {
            get { return bookingID; }
            set { bookingID = value; }
        }
       
        public Booking(Show show)
        {
            this.BookingID = BookingIDSequence.Instance.NextID;
            this.show = show;
            show.AddBooking(this);
            this.tickets = new List<ITicket>();
        }
        public void AddTickets(int number, TicketType type, decimal fee)
        {
            if (type == TicketType.Adult)
            {
                for(int i =0; i < number; i++)
                {
                    tickets.Add(new AdultTicket(show.Title, fee));
                }
            }
                else if (type == TicketType.Child)
                {
                    for(int i=0; i< number; i++)
                    {
                        tickets.Add(new ChildTicket(show.Title));
                     }
                }
            else if (type == TicketType.Family)
            {
                for (int i = 0; i < number; i++)
                {
                    tickets.Add(new FamilyTicket(show.Title, fee));
                }
             }
        }
       
        public string PrintTickets()
        {
            string ticketInfo = "Booking " + bookingID.ToString() + "\n";
            foreach (ITicket ticket in tickets)
            {
                ticketInfo += ticket.Print();
            }
            return ticketInfo;
        }
        public decimal TotalCost()
        {
            decimal totalCost;
            foreach (ITicket ticket in tickets)
            {
                totalCost += ticket.Fee;
            }
            return totalCost;
        }
        public override string ToString()
        {
            return string.Format("{0}: Total Cost={1:c}", bookingID, TotalCost());
        }
   
    }
}
