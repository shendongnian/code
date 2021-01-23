        DateTime targetDate = ......;
        DateTime tooLate = targetDate.AddDay(1);
         int count = DbContext.Tickets
                 .Count(tk=>
                           targetDate < tk.AddDateTime &&  tk.AddDateTime < tooLate
                           &&  arr.All(n=> tk.TicketNumbers.Any(tn=>tn.Number== n));
