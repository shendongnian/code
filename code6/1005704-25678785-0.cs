    ...
    .SetProjection(Projections.ProjectionList()
        .Add(Projections.Property("ContactName").As("SubClass.Name"))
        .Add(Projections.Property("EmailAddress").As("Email"))
    )
    .SetResultTransformer(DeepTransformer<MyClass>())
