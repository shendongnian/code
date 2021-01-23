    IList<DTO> result = session.QueryOver<A>(() => aAlias)
        .Full.JoinQueryOver(p => p.B, () => bAlias)
        .SelectList(list => list
            .Select(() => aAlias.Id).WithAlias(() => resultAlias.AId)
            .Select(() => aAlias.SomeData).WithAlias(() => resultAlias.SomeData)
            .Select(() => bAlias.Id).WithAlias(() => resultAlias.BId)
            .Select(() => bAlias.Deleted).WithAlias(() => resultAlias.Deleted)
            .Select(() => bAlias.Number).WithAlias(() => resultAlias.Number))
        .TransformUsing(Transformers.AliasToBean<DTO>())
        .List<DTO>();
