    public override Task<int> SaveChangesAsync()
    {
        this.SyncObjectsStatePreCommit();
        return base.SaveChangesAsync();
    }
