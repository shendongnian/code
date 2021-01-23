    public IList<T> List(int? roleId, int? sequence, string    name,System.Linq.Expressions.Expression<Func<User, T>> selector)
    {
       // ...
       query = query.OrderBy(x => x.UserId);
    
       return query.Select(selector).ToList();
    }
