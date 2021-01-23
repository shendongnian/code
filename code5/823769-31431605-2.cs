    public void RefreshAll()
    {
         foreach (var entity in ctx.ChangeTracker.Entries())
         {
               entity.Reload();
         }
    }
