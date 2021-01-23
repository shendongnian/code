    ticketGroups = troubletickets
                    .GroupBy(o => o.DueDate.HasValue
                                    ? o.DueDate.Value.ToShortDateString()
                                    : "")
                    .ToDictionary(g => g.Key, g => g.ToList());
