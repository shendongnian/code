    var list = session.QueryOver<Product>(() => productAlias)
        .JoinAlias(() => productAlias.ProductDetails, () => detailAlias)
        .WhereRestrictionOn(() => productAlias.Code).IsLike(search, MatchMode.Start)
        .AndRestrictionOn(() => detailAlias.Name).IsLike(search, MatchMode.Start)
        .List();
