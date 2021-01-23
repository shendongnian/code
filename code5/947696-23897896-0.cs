    var newTicket = MyService.GetTicket();
    var store = await WalletManager.RequestStoreAsync();
    var currentTickets = await store.GetItemsAsync();            
    if (currentTickets.Count(x => x.Id == newTicket.SerialNumber) == 1)
    {
        // the ticket exist so let's update it
        
        // get the "old" ticket from the Wallet store
        var ticket = currentItems.First(x => x.Id == newTicket.SerialNumber);
        // update the "old" ticket with the updated information
        ticket.DisplayName = newTicket.Name;
        ticket.BodyColor = Color.FromArgb(255, 255, 0, 0);
   
        // put the updated "old" ticket back in the store again
        await store.UpdateAsync(ticket);
    }
    else
    {
        // the ticket does not exist so let's add it
        await store.AddAsync(newTicket.SerialNumber, new WalletItem(WalletItemKind.Ticket, newTicket.Name)
            {
                BodyFontColor = Color.FromArgb(255, 255, 255, 255),
                BodyColor = Color.FromArgb(255, 50, 50, 230),
                DisplayName = newTicket.Name,
                ExpirationDate = newTicket.ExpireDate,
                IssuerDisplayName = "My Company"
            });
    }
