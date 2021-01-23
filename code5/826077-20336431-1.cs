    // Get the AccessProviders to delete
    IQueryable<AccessProviders> accessProviders = context.LoginBackEnds.SingleOrDefault(x => x.UserId == userId).AccessProviders;
    
    // Delete AccessProviders
    foreach(AccessProvider accessProvider in accessProviders)
    {
        context.AccessProviders.DeleteObject(accessProvider);
    }
    context.SaveChanges();
