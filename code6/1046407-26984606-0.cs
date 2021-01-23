    var ids = new List<int>();
    if (colourList != null && colourList.Any())
    {
        // Grab all ids from the first list
        ids = colourList[0].Select(c => c.Id).ToList();
        // Save only the intersection with each additional list
        for (int i = 1; i < colourList.Count; i++)
        {
            ids = ids.Intersect(colourList[i].Select(c => c.Id).ToList()).ToList();
        }
    }
    Console.WriteLine("The common ids are: {0}", string.Join(", ", ids));
