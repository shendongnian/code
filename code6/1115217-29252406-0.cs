    using (var context = ...)
    {
        // The query will return null, but will be executed.
        context.Clients.Where(GetEligibilityExpression())
                       .Where(() => false)
                       .SingleOrDefault(); 
    }
