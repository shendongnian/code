        public static IQueryable<T> ResolveQuotes<T>(this IQueryable<T> query)
        {
            var visitor = new ResolveQuoteVisitor();
            return query.Provider.CreateQuery<T>(visitor.Visit(query.Expression));
        }
