            Expression<Func<SearchResultItem, bool>> predicate = PredicateBuilder.True<SearchResultItem>();
            predicate = predicate.And(p => p.TemplateName.Equals("News"));
            predicate = predicate.And(p => p.Language == Context.Language.Name);
            List<SearchResultItem> results = context
                .GetQueryable<SearchResultItem>()
                .Where(predicate)
                .ToList();
