    public static IEnumerable<TEntity> FindLeafOnly<TEntity, TProperty>(
                               this IEnumerable<TEntity> leve11Data,
                               Func<TEntity, TProperty> idProperty,
                               Func<TEntity, TProperty> parentIdProperty)
                {   
                    IEnumerable<TProperty> allChild = leve11Data.Select(i => idProperty(i));
                    IEnumerable<TProperty> allParent = leve11Data.Select(i => parentIdProperty(i));
                    IEnumerable<TProperty> leafOnly = allChild.Except(allParent);
                    IEnumerable<TEntity> childItemsOnly = leve11Data.Where(i => leafOnly.Contains(idProperty(i)));
                    return childItemsOnly;
                }
