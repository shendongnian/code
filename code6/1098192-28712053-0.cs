         public void Send(string name, string message, string connectionid)
    {
        // Call the addNewMessageToPage method to update clients.
        Clients.All.addNewMessageToPage(name, message, connectionid);
    }
