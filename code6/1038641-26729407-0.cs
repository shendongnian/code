        public int Update<T>(T item) where T : class
        {
            Guard.ArgumentNotNull(item, "item");
            Set<T>().Attach(item);
            // Calling State on an entity in the Detached state will call DetectChanges() 
            // which is required to force an update. 
            Entry(item).State = EntityState.Modified;
            return SaveChanges();
        }
