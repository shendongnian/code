    public int CountPartialMatchingTicket(IList<int> numbers, DateTime day)
    {
        var arr = numbers.ToArray();
        int count = db.Tickets.Count(tk => tk.AddDateTime.Date == day.Date && arr.All(n=>     tk.TicketNumbers.Any(tn=>tn.Number== n)));
        return count;
    }
