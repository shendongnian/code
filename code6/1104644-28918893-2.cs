     class TicketManager
    {
        ObservableCollection<Ticket> tl = new ObservableCollection<Ticket>();
        internal ObservableCollection<Ticket> GetTickets()
        {
            tl.Add(new Ticket() { State = "State1", Text = "Text1", TicketNumber = 1 });
            tl.Add(new Ticket() { State = "State2", Text = "Text2", TicketNumber = 2 });
            tl.Add(new Ticket() { State = "State3", Text = "Text3", TicketNumber = 3 });
            
            return tl;
        }
    }
