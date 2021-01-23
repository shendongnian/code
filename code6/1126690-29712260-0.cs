    using(var context = new MyContext())
    {
        context.Configuration.LazyLoadingEnabled = false;
        // do your thing using .Include() or .Load()
        context.Configuration.LazyLoadingEnabled = true;
    }
