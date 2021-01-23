    _context.Configuration.ProxyCreationEnabled = false;
    var returnTicket = _context.Tickets
       .AsNoTracking()
       .Include(o => o.Lines.Select(l => l.Serials))
       .Include(o => o.Payments)
       .SingleOrDefault(o => o.TicketId == ticketId);
    _context.Configuration.ProxyCreationEnabled = true;
