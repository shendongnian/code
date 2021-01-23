    Category category = null
    result = Session.QueryOver(() => cat)
        // SELECT clause is now built
        .SelectList(list => list
            .Select(isSelected).WithAlias(() => category.IsSelected)
            .Select(ca => ca.Id).WithAlias(() => category.Id)
            ... // all properites we would like to be populated
        )
        // Transform results into Category again
        .TransformUsing(Transformers.AliasToBean<Category>())
        .List<Category>();
