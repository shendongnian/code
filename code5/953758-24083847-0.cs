    public IEnumerable<TEntity> Find<TEntity>(Dictionary<string, object> findValues = null) where TEntity : EntityObject
        {
            var entities = this.CreateObjectSet<TEntity>().ToList();
            if (findValues!= null && findValues.Count > 0)
            {
                foreach (var item in findValues)
                {
                    if(item.Value != null)
                        entities = entities.DynamicContains<TEntity>(item.Key, item.Value);
                }
            }
            return entities;
        }
