    var subsetGroups = arr1.Where(i1 => arr2.Contains(i1)).ToLookup(i => i);       
    int minGroupCount = 0;
    // check if all integers from the array are in the first at all
    if(arr2.All(i => subsetGroups.Contains(i)))
    {
        minGroupCount = subsetGroups.Min(g => g.Count()); // 2
    }
