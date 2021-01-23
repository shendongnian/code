    var criteria = CreateCriteria<MainTable>("Main")
        .SetProjection(
            Projections.ProjectionList()
                .Add(Projections.Property("Id"))
                .Add(Projections.Property("Name"))
    
                // here we go, let's profit from existing IProjection
                .Add(Projections.SubQuery(
                       DetachedCriteria
                           .For<RelatedTable>("Related")
                           .SetProjection(Projections.Sum("Value"))
                           .Add(Restrictions.EqProperty("Main.Id", "Related.MainTableId")))
                       , "value")
                    )
         ...
         ;
