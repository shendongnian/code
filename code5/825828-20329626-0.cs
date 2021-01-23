        public IEnumerable<T> GetDataWithIncludes<T>(string[] includes) where T: class, new()
        {
            DbQuery<T> dbQuery = null;
            DbSet<T> dbSet = this.Set<T>();
            foreach (string include in includes)
            {
                dbQuery = dbSet.Include(include);
            }
            return dbQuery.AsEnumerable();
        }
