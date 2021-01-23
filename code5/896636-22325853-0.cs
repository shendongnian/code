    //this loop must never be blocked
    while (!token.IsCancellationRequested)
    {
        var client = await AcceptClientAsync();
        HandleClientAsync(client); //must not block
    }
    Task HandleClientAsync(Client client) {
        if (await IsClientWrappableAsync(client)) //make async as well, don't block
            await HandleWrapperAsync(new MyWrapper(client));
    }
