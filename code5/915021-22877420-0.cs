    var properties = yourObjectType.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.SetProperty).Where(p => p.PropertyType == typeof(string)).ToList();
    var parameter = Expression.Parameter(yourObjectType,"p");
    var seed = PredicateBuilder.False<yourObjectType>();
    var whereExpression = properties.Aggregate(seed, (p1,p2) => p1.Or(GetNavigationExpression(parameter, yourSearchTerm,p2));
    var match = yourCollection.Where(whereExpression).ForEach(i => i.IsSelected = true);
