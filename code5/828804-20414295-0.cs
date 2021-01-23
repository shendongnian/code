    var query = context.Edge.Where(edge=>edge.BatteryStation.name.Equals(name) ||
                                         edge.BatteryStation1.name.Equals(name))
                       .SelectMany(edge => new []{ edge,
                                                new Edge{
                                                 BatteryStation = edge.BatteryStation1,
                                                 BatteryStation1 = edge.BatteryStation
                                                }
                                   });
    return query.ToList();
