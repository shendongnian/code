    var query = (from Ticket in entityContext.Tickets
                join Activity in entityContext.TicketActivities
                    on Ticket.ID equals Activity.TicketID into JoinedList // fields you made relationship base on those
                group JoinedList by Ticket into GroupedList
                select new {
                    Ticket = GroupedList.Key,
                    Activities = GroupedList.OrderBy(u => u.DateTime)
                })
                .OrderBy(u => u.SubmitDate)
                .ToList();
