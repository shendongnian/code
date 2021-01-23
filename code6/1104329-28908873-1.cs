    private IQueryable<Show> BuildQueryForLibrarySearchTerms(IEnumerable<LibraryShowSearchTerm> searchTerms)
        {
            IQueryable<Show> query = _repository.Get();
            IEnumerable<LibraryShowSearchTerm> includeTerms = searchTerms.Where(st=>st.Exclude.Equals(false));
            IEnumerable<LibraryShowSearchTerm> excludeTerms = searchTerms.Where(st=>st.Exclude.Equals(true));
            var predicate = LinqPredicateBuilder.False<Show>();
            var includePredicate = LinqPredicateBuilder.False<Show>();
            foreach (LibraryShowSearchTerm searchTerm in includeTerms)
            {
                string temp = searchTerm.SearchTerm;
                includePredicate = includePredicate.Or(show => show.ShowTitle.Contains(temp));
            }
            var excludePredicate = LinqPredicateBuilder.True<Show>();
            foreach (LibraryShowSearchTerm searchTerm in excludeTerms)
            {
                string temp = searchTerm.SearchTerm;
                excludePredicate = excludePredicate.And(show => !show.ShowTitle.Contains(temp));
            }
            predicate = includePredicate.And(excludePredicate);
            return query.Where(predicate);
        }
