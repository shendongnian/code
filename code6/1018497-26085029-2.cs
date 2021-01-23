    private IEnumerable<T> QueryCollection<T>() where T : BaseObj
    {
         IEnumerable<T> items = query<T>();
         if (typeof(ITeamFilterable).IsAssignableFrom(typeof(T)))
               items = (IEnumerable<T>)(object)FilterByTeams(items.Cast<ITeamFilterable>());
         return items;
    }
