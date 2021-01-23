    ctx.Configuration.LazyLoadingEnabled = false;
    
    var catWithRev = ctx.Categories
                    .Include(c => c.AccessRight.Roles)
                    .Include(c => c.AccessRight.Permissions)
                    //.Include(c => c.Revisions) --  not eagerly loaded
                    .FirstOrDefault(i => i.Id == id);
    // Explicitly load the filtered revisions
    ctx.Entry(catWithRev).Collection(cwr => cwr.Revisions).Query()
                    .OrderByDescending(r => r.DateCreated).Take(1)
                    .Load();
