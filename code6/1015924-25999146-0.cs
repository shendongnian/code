    // the As() is essential for result transformer
    query
        .UnderlyingCriteria
        .SetProjection(Projections.GroupProperty("PropertyNumber")
                                  .As("PropertyNumber"));
    // set Transformer
    query.TransformUsing(Transformers.AliasToBean<T>());
    // the list of T, but only PropertyNumber is filled by NHibernate
    var list = query.List<T>();
