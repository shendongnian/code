    var ids = new List<int>();
    if (colourList != null && colourList.Any())
    {
        // Grab all ids from the first list
        ids = colourList[0].Select(c => c.Id).ToList();
        // Save only the intersection with each additional list
        ids = colourList.Aggregate(ids, (cl1, cl2) => 
            cl1.Intersect(cl2.Select(c => c.Id)).ToList());
    }
    Console.WriteLine("The common ids are: {0}", string.Join(", ", ids));
