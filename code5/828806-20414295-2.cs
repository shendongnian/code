    var query = context.Edge.Where(edge=>edge.BatteryStation.name.Equals(name) ||
                                         edge.BatteryStation1.name.Equals(name));
    var edgeParam = Expression.Param(typeof(Edge),"edge");
    var edgeBA = Expression.New(typeof(Edge));
    var bind1 = Expression.Bind(typeof(Edge).GetProperty("BatteryStation"),
                                Expression.Property(edgeParam, "BatteryStation1"));
    var bind2 = Expression.Bind(typeof(Edge).GetProperty("BatteryStation1"),
                                Expression.Property(edgeParam, "BatteryStation"));
    var edgeBAInit = Expression.MemberInit(edgeBA, bind1, bind2);
    var edgeArray = Expression.NewArrayInit(typeof(Edge),edgeParam, edgeBAInit);
    var selectManyLambda = Expression.Lambda<Func<Edge,IEnumerable<Edge>>>(
                                      edgeArray, edgeParam);
    return query.SelectMany(selectManyLambda).ToList();
