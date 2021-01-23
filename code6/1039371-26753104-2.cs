    var x = 0;
    var result = list.Select((subList, idx) => new { Value = subList[1], Idx = idx })
                     .Where(elem => elem.Value < x)
                     .Select(elem => new { Diff = Math.Abs(x - elem.Value), elem.Idx })
                     .OrderBy(elem => elem.Diff).FirstOrDefault();
    
    if (result != null)
    {
        return result.Idx;
    }
    
    // case - there is no such index
