    public virtual IQueryable<TDTO> Get(ODataQueryOptions queryOptions)
            {
                if (queryOptions.SelectExpand == null)
                {
                    var selectOption = new SelectExpandQueryOption("Id,Name", string.Empty, queryOptions.Context);
                    Request.SetSelectExpandClause(selectOption.SelectExpandClause);
                }
    
                return (from m in Context.Get<MainDalObject>()
        select new MainObject 
        {
           Id = m.Id,
           Name = m.Description,
           Subs = m.Subs.Select(s => new SubObject 
           {
              Id = s.Id,
              Name = s.Name
           }
        });
    }
