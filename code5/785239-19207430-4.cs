    var listWithOr = session.QueryOver<Product>(() => productAlias)
       .JoinAlias(() => productAlias.ProductDetails, () => detailAlias)
       .Where(Restrictions.On(() => productAlias.Code).IsLike(search, MatchMode.Start)
            || Restrictions.On(() => detailAlias.Name).IsLike(search, MatchMode.Start))
       .List();
