    B bAlias = null;
    FlattenedDTO result = null;
    
    session.QueryOver<A>()
        .JoinQueryOver<AB>(a => a.ABs)
        .JoinQueryOver(ab => ab.B, () => bAlias)
        .SelectList(list => list
            .Select(a => a.Id).WithAlias(() => result.IdA)
            .Select(() => bAlias.Name).WithAlias(() => result.Name))
        .TransformUsing(Transformers.AliasToBean<FlattenedDTO>())
        .List<FlattenedDTO>()
        // At this point the query has been run and we just need to group the results
        .GroupBy(dto => dto.IdA, dto => dto.Name)
        .Select(grp => new DTO { IdA = grp.Key, Names = grp.ToList() });
