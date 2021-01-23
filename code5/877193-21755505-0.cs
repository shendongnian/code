    class ReferenceProduct {
        public string Name { get; set; }
        static readonly Dictionary<string, Func<string, LambdaExpression>> knownSortFactories =
        new Dictionary<string, Func<string,LambdaExpression>> {
            {"name", searchTerm =>(Expression<Func<ReferenceProduct, string>>)(p => p.Name.StartsWith(searchTerm) ? Convert.ToString((char)0) : p.Name) }
            // ... more here
        };
        public static IOrderedQueryable<ReferenceProduct> OrderProducts(IQueryable<ReferenceProduct> filteredProducts, string sortExpression, string sortDirection, string queryTerm)
        {
            Func<string, LambdaExpression> factory;
            if (!knownSortFactories.TryGetValue(sortExpression, out factory))
                throw new InvalidOperationException("Unknown sort expression: " + sortExpression);
            dynamic lambda = factory(queryTerm); // evil happens here ;p
            switch(sortDirection)
            {
                case "asc":
                    return Queryable.OrderBy(filteredProducts, lambda);
                case "desc":
                    return Queryable.OrderByDescending(filteredProducts, lambda);
                default:
                    throw new InvalidOperationException("Unknown sort direction: " + sortDirection);
            }
        }
    }
