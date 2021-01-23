        public static void ClearDbSet<T>(this DbContext context) where T : class {
            var entries = context.ChangeTracker.Entries<T>().Where(e => e.State == EntityState.Unchanged);
            
            foreach (DbEntityEntry<T> entry in entries.ToList()) {
                entry.State = EntityState.Detached;
            }
        }
