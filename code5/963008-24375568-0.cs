    public IdentityResult Validate( AppUser item )
    {
         IdentityResult result; 
         // do stuff
         return result;
    }
    public override Task<IdentityResult> ValidateAsync( AppUser item )
    {
        return Task.Run( () => Validate(item) );
    }
