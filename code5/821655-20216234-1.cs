        private static readonly PropertyInfo _OrganisationIDProperty = ReflectionAPI.GetProperty<OrganisationDependent, int>(o => o.OrganisationID);
        private static Expression<Func<TOrg, bool>> FilterByOrganization<TOrg>(int organizationId)
        {
            //The FilterByOrganisation method uses the LINQ Expressions API to generate an expression that will filter on organisation id
            //This avoids having to cast the set using .AsEnumerable().Cast<OrganisationDependent>().Where(x => x.OrganisationID == CurrentOrganisationID).AsQueryable().Cast<T>();
            //http://stackoverflow.com/questions/20052827/how-to-conditionally-filter-iqueryable-by-type-using-generic-repository-pattern
            var item = Expression.Parameter(typeof(TOrg), "item");
            var propertyValue = Expression.Property(item, _OrganisationIDProperty);
            var body = Expression.Equal(propertyValue, Expression.Constant(organizationId));
            return Expression.Lambda<Func<TOrg, bool>>(body, item);
        }
        public virtual IQueryable<T> All
        {
            get
            {
                if (typeof(T).IsSubclassOf(typeof(OrganisationDependent)))
                    return Context.Set<T>().Where(FilterByOrganization<T>(CurrentOrganisationID));
                return Context.Set<T>();
            }
        }
