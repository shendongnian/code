    var query = dataview.Provider.CreateQuery(
        Expression.Call(
            typeof( Queryable ),
            "Select",
            new Type[] { dataview.ElementType, dynamicType },
        Expression.Constant( dataview ), selector ) ).AsNoTracking();
    
    gReport.DataSource = query.OfType<object>().ToList();
    gReport.DataBind();
