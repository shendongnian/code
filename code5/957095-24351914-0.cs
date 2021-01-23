    public async Task AddToGroups(string[] names)
    {
        foreach (var name in names)
        {
            await Groups.Add(Context.ConnectionId, name);
            Clients.Group(name).sayHello("Hello", name);
        }
    }
