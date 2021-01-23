    public new async Task<ITspIdentity> FindByIdAsync(string id)
    {
       var tspIdentity = await base.FindByIdAsync(id).ConfigureAwait(false);
       return (ITspIdentity) tspIdentity;
    }
