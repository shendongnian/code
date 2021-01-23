    var c = ListB.Count();
    ListB = ListB
        .OrderBy(id => OrderedListToFollow.Contains(id)
            ? OrderedListToFollow.ToList().IndexOf(id)
            : c + 1    // This will always pace invalid objects at the end
        );
