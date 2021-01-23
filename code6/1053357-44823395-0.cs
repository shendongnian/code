    public override System.Threading.Tasks.Task<int> SaveChangesAsync()
    {
        foreach (var auditableEntity in ChangeTracker.Entries<ITrackableEntity>())
        {
            if (auditableEntity.State == EntityState.Added ||
                auditableEntity.State == EntityState.Modified)
            {
                // implementation may change based on the useage scenario, this
                // sample is for forma authentication.
                string currentUser = HttpContext.Current.User.Identity.GetUserId();
                DateTime currentDate = SiteHelper.GetCurrentDate();
                // modify updated date and updated by column for 
                // adds of updates.
                auditableEntity.Entity.ModifiedDateTime = currentDate;
                auditableEntity.Entity.ModifiedUserId = currentUser;
                // pupulate created date and created by columns for
                // newly added record.
                if (auditableEntity.State == EntityState.Added)
                {
                    auditableEntity.Entity.CreatedDateTime = currentDate;
                    auditableEntity.Entity.CreatedUserId = currentUser;
                }
                else
                {
                    // we also want to make sure that code is not inadvertly
                    // modifying created date and created by columns 
                    auditableEntity.Property(p => p.CreatedDateTime).IsModified = false;
                    auditableEntity.Property(p => p.CreatedUserId).IsModified = false;
                }
            }
        }
        return base.SaveChangesAsync();
    }
