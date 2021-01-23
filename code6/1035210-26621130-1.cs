    // I do this before when the dbcontext about to be saved :
    
            foreach (var dbEntityEntry in ChangeTracker.Entries())
            {
                var entityState = dbEntityEntry.Entity as IObjectState;
                if (entityState == null)
                    throw new InvalidCastException(
                        "All entites must implement " +
                        "the IObjectState interface, this interface " +
                        "must be implemented so each entites state" +
                        "can explicitely determined when updating graphs.");
    
                **dbEntityEntry.State = StateHelper.ConvertState(entityState.ObjectState);**
    
                var trackableObject = dbEntityEntry.Entity as ITrackableObject;
    
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
                    trackableObject.CreatedUserId = userId;
                }
    
                // set LastUpdatedDate for any case other than Unchanged
                if (entityState.ObjectState != ObjectState.Unchanged)
                {
                    trackableObject.LastUpdatedDate = dateTime;
                    trackableObject.LastUpdatedUserId = userId;
                }
            }
