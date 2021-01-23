    public List<Event> GetBySearch(EventFilter search)
    {
        IQueryable<Event> query = this.Context.Events.AsQueryable();
        if (search.CategoryId != 0)
        {
            query = query.Where(x => x.CategoryId == search.CategoryId);
        }
        if (search.SubCategoryId != 0)
        {
            query = query.Where(x => x.SubCategoryId == search.SubCategoryId);
        }
        return query.ToList();
    }
