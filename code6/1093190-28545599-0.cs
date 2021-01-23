    var localLanguages = context.Languages.ToList();
    foreach (var language in movie.SpokenLanguages)
    {
        if (localLanguages.Contains(language))
        {
            context.Languages.Attach(language);
            // no difference between both approaches
            context.Entry(language).State = EntityState.Unchanged;
        }
        else
        {
            // this entity does not yet have a primary key, tell EF
            // that it will get one during SaveChanges(Async)
            context.Languages.Add(language);
            // or
            context.Entry(language).State = EntityState.Added;
        }
    }
