    public List<Actor> GetActors([ModelBinder(BinderType = typeof(ConditionFilterBinder))] ConditionFilter conditionFilter = null)
    {
        //just to be sure, that we will not take some huge amount of data from database
        const int MAX_ACTOR_COUNT = 1000;
        var page = 0;
        var pageSize = MAX_ACTOR_COUNT;
        var actors = db.Actors;
        if (conditionFilter != null)
        {
            if(conditionFilter.OscarWinner.HasValue && conditionFilter.OscarWinner.Value)
            {
                actors = actors.Where(actor => actor.OscarWinner)
            }
            if (conditionFilter.Page.HasValue)
            {
                page = conditionFilter.Page.Value;
            }
            if (conditionFilter.PageSize.HasValue)
            {
                pageSize = conditionFilter.PageSize.Value > MAX_ACTOR_COUNT ? MAX_ACTOR_COUNT : conditionFilter.PageSize.Value;
            }
        }
        return actors.Skip(page * pageSize).Take(pageSize);
    }
