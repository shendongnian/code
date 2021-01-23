    var parameter = Expression.Parameter(typeof(House), "h");
    var body = Expression.Convert(
        Expression.Property(parameter, "Rooms")
    ,   typeof(IEnumerable<Room>)
    );
    var res = Expression.Lambda<Func<House,IEnumerable<Room>>>(body, parameter);
