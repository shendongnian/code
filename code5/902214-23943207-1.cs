    /// <summary>
    /// Returns a list of controllers available for the application.
    /// </summary>
    /// <returns>An <see cref="ICollection{Type}" /> of controllers.</returns>
    public override ICollection<Type> GetControllerTypes(IAssembliesResolver assembliesResolver)
    {
        HttpControllerTypeCacheSerializer serializer = new HttpControllerTypeCacheSerializer();
    
        // First, try reading from the cache on disk
        List<Type> matchingTypes = ReadTypesFromCache(TypeCacheName, IsControllerTypePredicate, serializer);
        if (matchingTypes != null)
        {
            return matchingTypes;
        }
    ...
    }
