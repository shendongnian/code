    public T GetSingle(System.Linq.Expressions.Expression<Func<T, bool>> filter = null)
        {
            //Check the local collection first
            IQueryable<T> localEntities = _dbset.Local.AsQueryable();
            if (filter != null)
            {
                localEntities = localEntities.Where(filter);
            }
            if (localEntities.Count() > 0)
            {
                return localEntities.FirstOrDefault();
            }
            else
            {
                //A local version of this was not found - try the database.
                IQueryable<T> query = this._dbset;
                if (filter != null)
                {
                    query = query.Where(filter);
                }
                return query.FirstOrDefault();
            }            
        }
