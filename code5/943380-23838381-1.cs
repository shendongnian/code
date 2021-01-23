    Files fAlias = null;
    Attrs aAlias = null;
    var disjunction = new Disjunction();
    disjunction.Add(Restrictions.On(() => aAlias.value)
        .IsLike("mode = read-only", MatchMode.Anywhere));
    disjunction.Add(Restrictions.On(() => aAlias.value)
        .IsLike("view = visible", MatchMode.Anywhere));
    var subquery = QueryOver.Of<Files_Attrs>
        .Inner.JoinAlias(x => x.file, () => fAlias)
        .Inner.JoinAlias(x => x.attr, () => aAlias)
        .Where(disjunction)
        .Select(() => fAlias);
    var files = session.QueryOver<Files>
        .WithSubquery.WhereExists(subquery)
        .List();
