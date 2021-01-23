    var getTicketTasks = new List<Task<IEnumerable<ITicket>>>();
    getTicketTasks.Add(Model.GetTicketsAsync(eventDate));
    getTicketTasks.Add(Model.GetGuestTicketsAsync(eventDate));
    ...
    getTicketTasks.Add(Model.GetOtherTicketsAsync(eventDate));
    IEnumerable<ITicket>[] tickets = await Task.WhenAll(getTicketTasks);
