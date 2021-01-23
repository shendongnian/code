    Cat parent = null;
    CatSkills child = null;
    // this is in fact a subselect, which will be injected into parent's SELECT
    var subQuery = QueryOver.Of<CatSkills>(() => child)
        .Where(() => child.Cat.ID == parent.ID)
        .Select(Projections.RowCount());
    // the alias here is essential, because it is used in the subselect
    var query = session.QueryOver<Cat>(() => parent);
    query.SelectList(l => l
        .Select(p => p.ID).WithAlias(() => parent.ID)
        .Select(p => p.Name).WithAlias(() => parent.Name)
        // see the parent.Count property
        .Select(Projections.SubQuery(subQuery)).WithAlias(() => parent.Count)
        );
    query.TransformUsing(Transformers.AliasToBean<Cat>());
