    var predicate2 = PredicateBuilder.False<Person>();
    foreach (var item in items.GroupBy(x => x.Name).SelectMany(x => x.OrderBy(y => y.Id).Take(1)))
    {
        predicate2 = predicate2.Or(p => p.Id == item.Id);
    }
    var fnc2 = predicate2.Compile();
    var filtered2 = allItems.Where(fnc2).ToList();
