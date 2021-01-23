    public static Site Update(Site _updatedSite)
      {
         using (DragonRentalsEntities context = new DragonRentalsEntities(new ConfigurationManager().ConnectionString))
         {
              
              if (context.Entry(_updatedSite).State == EntityState.Detached)
                   context.Entry(_updatedSite).State = EntityState.Modified;// attaches  entity and marks it as modified if it is detached
              
              context.SaveChanges();
              return _updatedSite; //after save changes u have the same object as u send in your Update function
        }
      }
