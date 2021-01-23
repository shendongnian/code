    var list1 = new[] {
        Tuple.Create("Infected Mushroom", "Classical Mushroom"),
        Tuple.Create("Infected Mushroom", "Converting Vegetarians"),
        Tuple.Create("Skazi", "Animal")
    }
    .GroupBy(t => t.Item1, t => t.Item2);
    var list2 = new[] {
        Tuple.Create("Infected Mushroom", "The Gathering"),
        Tuple.Create("Skazi", "Animal")
    }
    .GroupBy(t => t.Item1, t => t.Item2);
