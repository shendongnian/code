        public IEnumerable<DeviceInstance> GetFiltered(
            Func<IQueryable<DeviceInstance>, IOrderedQueryable<DeviceInstance>> orderBy = null, 
            int? Page = 0,
            int numberOfIncludeExpressions = 0,
            params System.Linq.Expressions.Expression<Func<DeviceInstance, bool>>[] expressions)
        {
            IQueryable<DeviceInstance> query = dbSet;
            if (expressions != null)
            {
                foreach (var z in expressions.Take(numberOfIncludeExpressions))
                {
                    query = query.Include(z);
                }
            
                foreach (var z in expressions.Skip(numberOfIncludeExpressions))
                {
                    query = query.Where(z);
                }
            }
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
