    public async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
    {
        Guid token;
        
        if (Guid.TryParse(context.Token, out token))
        {
            AuthenticationTicket ticket;
            
            if (_refreshTokens.TryRemove(ComputeHash(token), out ticket))
            {
                context.SetTicket(ticket);
            }
        }
    }
    
