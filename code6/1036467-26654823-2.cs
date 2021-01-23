        public void DeleteAll<T>(IEnumerable<T> items) where T : class
        {
            Guard.ArgumentNotNull(items, "items");
            var autoDetectChangesEnabledBefore = Configuration.AutoDetectChangesEnabled;
            var validateOnSaveEnabled = Configuration.ValidateOnSaveEnabled;
            // It is said to make the performance better.
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.ValidateOnSaveEnabled = false;
            foreach (var item in items)
            {
                Set<T>().Attach(item);
                Set<T>().Remove(item);
            }
            SaveChanges();
            Configuration.AutoDetectChangesEnabled = autoDetectChangesEnabledBefore;
            Configuration.ValidateOnSaveEnabled = validateOnSaveEnabled;
        }
