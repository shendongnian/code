    List<Private.Database.DailyItem> items;
    using (var context = new Private.Database.PrivateDb())
    {
        // context.Configuration.LazyLoadingEnabled = false;
        items = context.DailyItem.OrderBy(c => c.sortOrder).OrderByDescending(c => c.isFavorite).ToList();
    }
