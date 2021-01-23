    public override ReadOnlyCollection<ClaimsIdentity> ValidateToken( 
                                                          SecurityToken token)
    {
       ClaimsPrincipal validated = ValidateToken(token as JwtSecurityToken, 
                                                 validationParameters);
       var result = new ReadOnlyCollection<ClaimsIdentity>(
                           validated.Identities.ToList());
       return result;
    }
