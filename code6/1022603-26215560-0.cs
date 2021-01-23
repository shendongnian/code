    MyModel main = null;
    MyModelDTO dto = null;
    // the main query
    var query = session.QueryOver<MyModel>(() => main);
    // the subquery used for projection
    var subquery = QueryOver.Of<OtherModel>()
        // select something, e.g. count of the ID
        .SelectList(selectGroup => selectGroup.SelectCount(o => o.ID))
        // some condition
        // kind of JOIN inside of the subquery
        .Where(o => o.xxx == main.yyy); // just example
    // now select the properties from main MyModel and one from the subquery
    query.SelectList(sl => sl
          .SelectSubQuery(subquery)
             .WithAlias(() => dto.Count)
          .Select(() => main.ID)
            .WithAlias(() => dto .ID)
          ....
        );
    // we have to use transformer
    query.TransformUsing(Transformers.AliasToBean<MyModelDTO >())
    // and we can get a list of DTO
    var list = query.List<MyModelDTO>();
