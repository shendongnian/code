    public IQueryable<TitlePoco> TranslateTitles(IQueryable<Title> query)
    {
      return query.Select(n => new TitlePoco { 
                    ID = n.ID,
                    Name= n.Name,
                    StartTime = System.Data.Objects.EntityFunctions.AddMinutes(n.StartTime, 30)
                });
    }
