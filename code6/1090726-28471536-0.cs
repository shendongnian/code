    public virtual IQueryable<T> GetAll(
            Func<T,object> predicate,
            Sorted _sort = Sorted.ASC,
            int _max = 0,
            int _skip = 0
            ) {
                IQueryable<T> query = _sort == Sorted.ASC ? //Sorted is enum
                    _entities.Set<T>().OrderBy(predicate).Skip(_skip).Take(_max) :
                    _entities.Set<T>().OrderByDescending(predicate).Skip(_skip).Take(_max);
    
                return query;
           }
