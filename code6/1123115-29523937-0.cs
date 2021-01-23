    //TODO come up with a better name
    List<TypeA> GetItemsAsLists(string s, out List<TypeB> otherItems)
    {
        IEnumerable<TypeB> tempEnumerable;
        var output = Fns.GetItems(s, out tempEnumerable).ToList();
        otherItems = tempEnumerable.ToList();
        return output.ToList();
    }
