    object alias = null;
    var result = session.QueryOver(type.FullName, () => alias)
        .SelectList(list => list
        .Select(Projections.Id())
        .Select(Projections.Property("RoleId"))
        .Select(Projections.Property("Name")))
        .TransformUsing(Transformers.PassThrough)
        .List<object[]>();
