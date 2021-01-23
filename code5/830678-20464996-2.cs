    public void DisplayCalcQuery(string argFromQueryBuilder)
    {
    if (!String.IsNullOrWhiteSpace(argFromQueryBuilder))
    {
        //notify closure of query builder
        _QueryBuilderIsOpen = false;
        UserBuiltQueries.Add(argFromQueryBuilder);
        //displayng the user built query(queries) on the stack panel meant to display it. 
        var lastItem = UserBuiltQueries[UserBuiltQueries.Count - 1];
        //removing all $signs from the obtained string
        lastItem = lastItem.Replace(@"$", "");
        addBuiltCheck(lastItem); 
    }
    else
    {
        //notify closure of query builder
        _QueryBuilderIsOpen = false;
    }
}
