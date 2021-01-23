    private static Thing GetThing(string key, IEnumerable<Thing> things)
    {
        var thingList = things.ToList();
        return new Thing()
        {
            First = thingList.Count() == 1 ? thingList.First().First : string.Empty, 
            Group = key,
            Things = thingList.Count() == 1 ? null : 
                            thingList.Where(t => t.First != string.Empty).ToList(),
        };
    }
