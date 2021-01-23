    var getTicketTasks = new List<Task<IEnumerable<ITicket>>>();
    getTicketTasks.Add(Task.Run(() => Model.GetTicketsAsync(eventDate)));
    getTicketTasks.Add(Task.Run(() => Model.GetGuestTicketsAsync(eventDate)));
    ...
    getTicketTasks.Add(Task.Run(() => Model.GetOtherTicketsAsync(eventDate)));
    IEnumerable<ITicket>[] tickets = await Task.WhenAll(getTicketTasks);
