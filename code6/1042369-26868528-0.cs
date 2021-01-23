        public override int SaveChanges()
        {
            foreach( var entry in this.ChangeTracker.Entries() )
            {
                if( entry.State == EntityState.Added && 
                    entry.CurrentValues.PropertyNames.Contains( "CreatedAt" ) )
                {
                    entry.CurrentValues[ "CreatedAt" ] = DateTime.Now;
                }
            }
            
            return base.SaveChanges();
        }
