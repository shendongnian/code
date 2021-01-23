     public void Update(IEnumerable<MyParentType> parents)
     {
       try
       {
           foreach (var parent in parents)
           {
             if(parent.Id==0)
             {
              _context.MyParentTypes.Add(parent);
             }
             else
             { 
                //When you change the state to Modified all the scalar properties of the entity will be marked as modified
               _context.Entry(parent).State = EntityState.Modified;
                foreach(var child in parent.children)
                {
                   context.Entry(lodging).State =child.Id>0? EntityState.Modified:EntityState.Added;  
                }
             }
           }
           
           _context.SaveChanges();
       }
       catch (Exception exception)
       {
         _logger.Error(exception.Message, exception);
       }
    }
