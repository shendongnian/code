    // Simple Linq, but just not good enough
    // Need to also propagate original input order and count the number of siblings
    Func<IEnumerable<Item>, Item, IEnumerable<Item>> SelectSuccessors = (set, item) => set.Where(i => i.ID == item.nextID);
    Func<IEnumerable<Item>, IEnumerable<Item>, IEnumerable<Item>> Flatten = null;
    Flatten = (set, sibblingPool) => set
        .SelectMany(i => new[] { i }.Concat(Flatten(SelectSuccessors(sibblingPool.Except(set), i), sibblingPool.Except(set))));
    var unparented = items.Where(i => !items.Any(n => n.nextID == i.ID));
    foreach (var item in Flatten(unparented, items))
        Console.WriteLine(item.ID);
