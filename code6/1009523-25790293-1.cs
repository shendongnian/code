    private async Task RetrieveUsers()
    {
        Parallel.ForEach(Computers, c =>
        {
            string user = await GetUserName(c.Name); // or c.IP. both work.
        });
    }
