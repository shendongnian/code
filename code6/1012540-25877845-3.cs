    var items = new List<HashSet<string>>
    {
        new HashSet<string> {"1", "2"},
        new HashSet<string> {"2", "3"},
        new HashSet<string> {"3", "4"},
        new HashSet<string>{"1", "4"}
    };
    var intersects = items.AsParallel().Select(     //Outer loop to run on all items
        item => items.AsParallel().Select(          //Inner loop to calculate intersects
                item2 => item.Intersect(item2).Count())
                //This ToList will create a single List<int>
                //with the intersects for that item
                .ToList() 
            //This ToList will create the final List<List<int>>
            //that contains all intersects.
            ).ToList();
