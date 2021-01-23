    var query = dataview.Provider.CreateQuery(
        Expression.Call(
            typeof( Queryable ),
            "Select",
            new Type[] { dataview.ElementType, dynamicType },
        Expression.Constant( dataview ), selector ) ).AsNoTracking();
    // enumerate thru the query results and put into a list
    var listResult = new List<object>();
    var enumerator = query.GetEnumerator();
    while ( enumerator.MoveNext() )
    {
        reportResult.Add( enumerator.Current );
    }
    
    gReport.DataSource = listResult;
    gReport.DataBind();
