    var strings = new [] { "burg", "wood", "town" };
    // just some sample data
    var cities = new[] { new City("Capetown"), new City("Hamburg"), new City("New York"), new City("Farwood") };
    var param = Expression.Parameter(typeof(City));
    var cityName = Expression.PropertyOrField(param, "Name"); // change the property name
    Expression condition = Expression.Constant(false);
    foreach (var s in strings)
    {
        var expr = Expression.Call(cityName, "Contains", Type.EmptyTypes, Expression.Constant(s));
        condition = Expression.OrElse(condition, expr);
    }
    // you can apply the .Where call to any query. In the debugger view you can see that
    // the actual expression applied is just a bunch of OR statements.
    var query = cities.AsQueryable().Where(Expression.Lambda<Func<City, bool>>(condition, param));
    var results = query.ToList();
    // the class used in the test
    private class City
    {
        public City(string name) { this.Name = name; }
        public string Name;
    }
