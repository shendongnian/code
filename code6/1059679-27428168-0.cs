    using(var context = new YourContextNameHere(SPContext.Current.Site.Url))
    {
        var title = context.DataLibrary
            .Where(item => item.ID == id)
            .Select(item => item.Title)//to avoid pulling down other columns
            .First();
    }
