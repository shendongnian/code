        public T Find(int id)
        {
            var entity = Context.SingleOrDefault(x => x.Id == id);
            if (entity != null)
            {
                foreach(var property in entity.GetType()
                    .GetProperties()
                    .Where(info => info.CustomAttributes.OfType<FilteredNavigationProperty>().Any()))
                {
                    var collection = (property.GetValue(property) as IQueryable<IEntity>);
                    collection = collection.Where(spec.PredicateBuilder.Complete());
                }
            }
            return entity;
        }
