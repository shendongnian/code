    foreach (EntityBase entity in orderedEntities.ToList())
    {
        sources.Add(new SourceView
        {
            EntityBaseKey = entity.Source.EntityBaseKey,
            SourceName = entity.EntityName,           
        });
    }
