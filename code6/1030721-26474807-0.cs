    IQueryable<ServiceTicket> troubletickets = db.ServiceTickets
                                                 .Include(t => t.Company)
                                                 .Include(t => t.UserProfile);
    
    Dictionary<string, List<ServiceTicket>> ticketGroups = 
                    troubletickets
                   .GroupBy(ticket => ticket.DueDate)
                   .AsEnumerable() // Continue in memory
                   .ToDictionary(g => g.Key.HasValue 
                                            ? g.Key.Value.ToShortDateString() 
                                            : string.Empty,
                                      g => g.Select(ticket => ticket));
