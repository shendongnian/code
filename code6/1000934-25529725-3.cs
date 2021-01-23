    var ret = new List<ISomething>();
    if (select)
    {
        ret.AddRange(aValues);
    }
    else
    {
        ret.AddRange(bValues);
    }
    return ret;
