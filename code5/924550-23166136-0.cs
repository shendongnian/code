    // this would be the collector of criteria
    var restrictions = new List<ICriterion>();
    
    if (filter.Owner.HasValue)
    {
        restrcitons.Add(Expression.Disjunction()
            .Add(Restrictions.Eq("ou.User.Id", filter.Owner.Value))
            .Add(Restrictions.Eq("ou.Status", 0))
        );
    }
    
    if (filter.Watcher.HasValue)
    {
        restricitons.Add(Expression.Disjunction()
                .Add(Restrictions.Eq("ou.User.Id", filter.Watcher.Value))
                .Add(Restrictions.Eq("ou.Status", 1))
        );
    }
    
    if (filter.CreatedBy.HasValue)
    {
        restrictions.Add(Restrictions.Eq("u.Id", filter.CreatedBy));
    }
    
    // now we can inject the result of the above code into 
    // Disjunction or Conjunction...
    if(restrictions.Count > 0)
    {
        var disjunction = Restrictions.Disjunction();
        restrictions .ForEach(r => disjunction.Add(r));
        criteria.Add(disjunction)
    }
