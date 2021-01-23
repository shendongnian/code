    public override async Task<IdentityResult> CreateAsync(User user, string password)
    {
        try
        {
            return await base.CreateAsync(user, password);
        }
        catch (DbEntityValidationException ex)
        {
            var errors = ex.EntityValidationErrors
                .Where(e => e.IsValid)
                .SelectMany(e => e.ValidationErrors)
                .Select(e => e.ErrorMessage)
                .ToArray();
            return new IdentityResult(errors);
        }
    }
