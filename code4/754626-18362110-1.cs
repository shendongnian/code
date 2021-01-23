    public IQueryable<Event> GetBySearch(EventFilter search)
    {
        IQueryable<Event> events = this.Context.Events; //(I assume Events is an IQueryable<Event>)
 
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
