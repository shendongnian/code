    public Expression<Func<T, object>> GetLambdaExpressionForSortProperty(string propertyname) where T : class
    {
        Expression member = null;
        var propertyParts = propertyname.Split(new[]{'.'}, StringSplitOptions.RemoveEmptyEntries);
        var param = Expression.Parameter(typeof(T), "arg");
        Expression previous = param;
        foreach(string s in propertyParts)
        {
            member = Expression.Property(previous, s);
            previous = member;
        }
        if(member.Type.IsValueType)
        {
            member = Expression.Convert(member, typeof(object));
        }
        return Expression.Lambda<Func<T, object>>(member, param);
    }
    protected void gridView_OnSorting(object sender, GridViewSortEventArgs e)
    {
        var orderby = GetLambdaExpressionForSortProperty<DataModel>(e.SortExpression);
        var sortedData = YourDataArray.OrderByAscending(orderby).ToList();
        gridView.DataSource = sortedData;
        gridView.DataBind();
    }
