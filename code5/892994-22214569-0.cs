    public static class MapperExtensions    
    {
         public static TQuickbooksEntity ToQuickBooksEntity<TExternalEntity>(this TExternalEntity externalEntity, CompanyPreferencesFinancialsSystemCommon preferences) 
                            where TExternalEntity : class, OTIS.Domain.IEntity, new()
                            where TQuickbooksEntity : class, Intuit.Ipp.Data.IEntity, new()
         {    
              //return do implimentation    
         }
    }
