    var idDateQuery = from item in _session.GetAllAdvacnedTickets()
                      orderby item.BasicTicket.Id, item.CreatedDate descending
                      select item;
    var query = from item in _session.GetAllAdvacnedTickets()
                let top = idDateQuery.First(o => o.BasicTicket.Id == item.BasicTicket.Id)
                where item.Id == top.Id
                select item;
