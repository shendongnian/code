    public IQueryable<Event> GetBySearch(EventFilter search)
    {
        var events = this.Context.Events;
 
        if (search.CategoryId != 0)
        {
            events = events.Where(x => x.CategoryId == search.CategoryId);
        }
        if (search.SubCategoryId != 0)
        {
            events = events.Where(x => x.SubCategoryId == search.SubCategoryId);
        }
        return events;
    }
