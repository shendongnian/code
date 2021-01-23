    // these will server as fully-type representatives, and aliases
    Shop shop = null;
    City city = null;
    MyDTO dto = null;
    
    // shop query
    var query = session.QueryOver<Shop>(() => shop);
    // if needed a reference to criteria of the city
    var cityPart = query.JoinQueryOver(() => shop.City // reference
        , () => city // alias
        , JoinType.LeftOuterJoin); // left join
    
    // SELECT Clause
    query.SelectList(list => list
        .Select(() => shop.Id)
            .WithAlias(() => dto.Id)
        .Select(() => shop.Name)
            .WithAlias(() => dto.Name)
    
        // Conditional here
        .Select(Projections.Conditional(
                    Restrictions.Where(() => city.NameES== null),
                    Projections.Constant("---", NHibernateUtil.String),
                    Projections.Property(() => city.NameES)
            ))
            .WithAlias(() => dto.NameEs)
        );
    
    var result = query
        .TransformUsing(Transformers.AliasToBean<MyDTO>())
        .List<MyDTO>();
