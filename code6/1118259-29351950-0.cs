     public void Update(IEnumerable<MyParentType> parents)
     {
        try
        {
           Add(parents.Where(x => x.parentID == 0));
           var updatedData = parents.Where(x => x.parentID != 0);
           foreach (var parent in updatedData)
           {
               _context.UpdateGraph(parent, map => map.OwnedCollection(p => p.children));
               _context.SaveChanges();
          }
               
       }
       catch (Exception exception)
       {
         _logger.Error(exception.Message, exception);
       }
    }
