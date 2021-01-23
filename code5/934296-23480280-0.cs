    public async Task JoinGroup(string groupName, string userFullName)
    {
        await Groups.Add(Context.ConnectionId, groupName);
        // Send data back to everyone including the caller   
        Clients.Group(groupName).dataChanged(...);
    }
