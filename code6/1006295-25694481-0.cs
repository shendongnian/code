     public int CountPartialMatchingTicket(IList<int> numbers)
     {
         var arr = numbers.ToArray();
         int count = DbContext.Tickets
                 .Count(tk=>arr.All(n=> tk.TicketNumbers.Any(tn=>tn.Number== n));
         return count;
     }
