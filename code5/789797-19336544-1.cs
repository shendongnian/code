    public List<Event> GetEventsForAdmin()
    {
        using (var dbEntities = new CapeledEntities())
        {
            return (from e in dbEntities.Events
                    join lnk in dbEntities.linkEventCategories on e.EventId equals lnk.EventId
                    join cat in dbEntities.Categories on lnk.CategoryId equals cat.CategoryId
                    orderby e.StartDateTime descending
                    select new Event() { 
                                    .EventId = e.EventId, 
                                    .EventTitle = e.Title,
                                    .StartDateTime = e.StartDateTime,
                                    .Description = e.Description, 
                                    .CatTitle = cat.Title 
                   }
            ).ToList();
        }
    }
