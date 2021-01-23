    // Exception number 2627 = Violation of %ls constraint '%.*ls'. Cannot insert duplicate key in object '%.*ls'.
    // Exception number 2601 = Cannot insert duplicate key row in object '%.*ls' with unique index '%.*ls'.
    // See http://msdn.microsoft.com/en-us/library/cc645603.aspx for more information and possible exception numbers
    if (innerException != null && (innerException.Number == 2627 || innerException.Number == 2601))
    {
        // Resolve the primary key conflict by refreshing and letting the store win
        // In order to be able to refresh the entity its state has to be changed from Added to Unchanged
        ObjectStateEntry ose = ex.StateEntries.Single();
        this.ObjectStateManager.ChangeObjectState(ose.Entity, EntityState.Unchanged);
        base.Refresh(RefreshMode.StoreWins, ose.Entity);
        // Refresh addedChanges now to remove the refreshed entry from it
        addedChanges = this.ObjectStateManager.GetObjectStateEntries(System.Data.EntityState.Added).Where(s => !s.IsRelationship);
    }
    else
    {
        throw;
    }
