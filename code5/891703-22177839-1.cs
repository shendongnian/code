    var predicate = PredicateBuilder.False<Car>();
    carSearchObjects
    .ForEach(a => predicate = predicate.Or(p => p.Id == a.Id && p.Model == a.Model));
    
    var carsFromQuery = context.Cars.AsExpandable().Where(predicate);
