     .Where(TicketsToShow.And(SearchVals))
       select new 
       {
           Priority = ticket.TicketPriority.TicketPriorityName,
           Ticket = string.Format(TicketFormat, ticket.TicketID),
           AssetId = ticket.Asset.Serial,
           OpenDate = ticket.CheckedInDate,
           OpenFor = CalculateOpenDaysAndHours(ticket.CheckedInDate, ticket.ClosedDate),
           Account = ticket.Account.Customer.Name,
           Description = ticket.Description.Replace("\n", ", "),
           Status = ticket.TicketStatus.TicketStatusName,
           Closed = ticket.ClosedDate,
           //Use Sum and the foreign relation instead of a nested query
           Amount = ticket.ProductChargeItems.Where(pci => pci.Deleted == null).Sum(pci => pci.Qty * pci.Price),
           Paid = ticket.Paid,
           Warranty = ticket.WarrantyRepair,
           AssetLocation = GetAssetLocationNameFromID(ticket.Asset.LocationID, AssLocNames)
       }).Skip(totalToDisplay * page).Take(totalToDisplay);
       if (SortOrder.ToLower().Contains("Asc".ToLower()))
       {
           query = query.OrderBy(p => p.OpenDate);
       }
       else
       {
           query = query.OrderByDescending(p => p.OpenDate);
       }
