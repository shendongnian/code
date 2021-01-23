    public IQueryable<TitlePoco> TranslateTitles(IQueryable<Title> query)
    {
      return query.Select(n => new TitlePoco { 
                    Title = n,
                    StartTime = System.Data.Objects.EntityFunctions.AddMinutes(n.StartTime, 30)
                });
    }
