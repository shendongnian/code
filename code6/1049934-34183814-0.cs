    public async Task<AuthenticateResult> AuthenticateAsync(string authenticationType)
    {
      IEnumerable<AuthenticateResult> source = await this.AuthenticateAsync(new string[] { authenticationType });
      return source.SingleOrDefault<AuthenticateResult>(); //<== this line throws because there are two  
    }
