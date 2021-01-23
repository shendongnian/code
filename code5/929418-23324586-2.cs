    Using System.Data.Objects.SqlClient;
     var searchTickets = db.Tickets
            .Where(t => t.StatusID != 3 && 
                SqlFunctions.StringConvert((double)t.TicketID).StartsWith(term)
            .Take(10)
            .Select(t => new
            {
                label = t.Summary
            });
