     public IEnumerable<NPISItem> ExistingNPISItemsCollection
      {
         get
         {
            return NPISItemsCollection == null 
                       ? Enumerable.Empty<NPISItem>() 
                       : NPISItemsCollection .Where(d => !d.IsDeleted);
         }
      }
