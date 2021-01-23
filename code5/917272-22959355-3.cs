    IEnumerable<IRelatedEnd> relEnds = ((IEntityWithRelationships) originalEntity).RelationshipManager.GetAllRelatedEnds();
    
     foreach (IRelatedEnd relatedEnd in relEnds)
     {
       if (relatedEnd is EntityReference)
       {
          continue;
       }
    
       relatedEnd.Load();
    
       if (relatedEnd.CreateSourceQuery().OfType<EntityObject>().Any())
       {
         string exceptionMessage = string.Format("{0} cannot be deleted, because {1} refers to it",
                                                                  originalEntity.GetType().Name, 
                                                                  relatedEnd.CreateSourceQuery().OfType<EntityObject>().First().GetType().Name);
    
         throw new Exception(exceptionMessage);
       }
    }
