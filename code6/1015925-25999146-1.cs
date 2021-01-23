    query
        .UnderlyingCriteria
        .SetProjection(
          Projections.ProjectionList()
            .Add(Projections.GroupProperty("PropertyNumber").As("PropertyNumber"))
            .Add(Projections.Count("ID").As("Count"))
            ....
        )
        ;
    // set Transformer to some DTO
    query.TransformUsing(Transformers.AliasToBean<U>());
    // the list of DTO, with more than PropertyNumber filled
    var list = query.List<U>(); // generic U representing DTO
