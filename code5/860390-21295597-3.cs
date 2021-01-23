    public class WhateverContext : DbContext
    {
       // Some behavior and all...
       public override int SaveChanges()
       {
          // Added ones...
          var _entitiesAdded = ChangeTracker.Entries()
             .Where(_e => _e.State == EntityState.Added)
             .Where(_e => _e.Entity.GetType().GetInterfaces().Any(_i => _i == typeof(IAuditCreated)))
             .Select(_e => _e.Entity);
          foreach(var _entity in _entitiesAdded) { /* Set date and user */ }
          // Changed ones...
          var _entitiesChanged = ChangeTracker.Entries()
             .Where(_e => _e.State == EntityState.Modified)
             .Where(_e => _e.Entity.GetType().GetInterfaces().Any(_i => _i == typeof(IAuditChanged)))
             .Select(_e => _e.Entity);
          foreach(var _entity in _entitiesChanged) { /* Set date and user */ }
          // Save...
          return base.SaveChanges();
       }
    }
