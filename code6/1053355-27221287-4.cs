    internal static class ContextHelper
    {
        internal static void SyncObjectsStatePreCommit(this DbContext dbContext)
        {
            foreach (var dbEntityEntry in dbContext.ChangeTracker.Entries())
            {
    
                // do any other stuff you want.
                // ..
                // ..
    
                // work with ITrackable entities
                var trackableObject = dbEntityEntry.Entity as ITrackable;
    
                // we need to set/update trackable properties
                if (trackableObject == null)
                {
                    continue;
                }
    
                var dateTime = DateTime.Now;
    
                // set createddate only for added entities
                if (entityState.ObjectState == ObjectState.Added)
                {
                    trackableObject.CreatedDate = dateTime;
                }
    
                // set LastUpdatedDate for any case other than Unchanged
                if (entityState.ObjectState != ObjectState.Unchanged)
                {
                    trackableObject.ModifiedDate = dateTime;
                }
            }
        }
    }
