    // Item1 = min, Item2 = max, Item3 = character class
    IList<Tuple<int, int, char>> ranges = new List<Tuple<int, int, char>>();
    // init your ranges here
    int num = 1;
    // assuming that there certainly is a range which fits num,
    // otherwise use "OrDefault"
    // it may be good to create wrapper for Tuple, 
    // or create separate class for your data
    char characterClass = ranges.
                            First(i => num.IsBetween(i.Item1, i.Item2)).Item3;
