    public int CountPartialMatchingTicket(IList<int> numbers, DateTime day)
    {
        var arr = numbers.ToArray();
        int count = db.Tickets.Count(tk => DbFunctions.TruncateTime(tk.AddDateTime) == DbFunctions.TruncateTime(day) && arr.All(n=>     tk.TicketNumbers.Any(tn=>tn.Number== n)));
        return count;
    }
