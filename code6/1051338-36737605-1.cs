    using HelperExtesionMethods
    DbContext context = new DbContext();
    public IEnumerable<string> GetExistingNames(ICollection<string> names)
    {
        IQueryable<Names> query = context.Names.Where(n => names.UpdateNullString().Contains(n.Name.UpdateNullString()));
        if(query == null) yield break;
        foreach(var name in query)
        {
            yield return name.Name;
        }
    }
