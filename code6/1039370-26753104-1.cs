    var x = 0;
    var result = list.Select(subList => subList[1])
                   .Where(elem => elem < x)
                   .Select((elem, index) => new
                                            {
                                                Diff = Math.Abs(x - elem),
                                                Idx = index
                                            })
                   .OrderBy(elem => elem.Diff).FirstOrDefault();
    
    if (result != null)
    {
        return result.Idx;
    }
    
    // case - there is no such index
