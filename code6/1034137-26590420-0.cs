    public ActionResult OpenTickets()
    {
        var openTickets = ticketRepo.GetOpenTickets();
        return View(openTickets);
    }
    // Implementation of ITicketRepo
    public IEnumerable<OpenTickets> GetOpenTickets()
    {
        return db.Ticket
            .Where(t => t.idFirma == 1 && t.Zatvoren == false)
            .Select(do => new OpenTickets
            {
                // Fill in view model properties from database object
            });
    }
