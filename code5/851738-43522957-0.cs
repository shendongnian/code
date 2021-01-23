        async Task LoginAsync(string user, string password)
        {
            Remote.Login(user, password);
            await Task.FromResult(0);
        }
