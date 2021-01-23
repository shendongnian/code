    var alist = new List<AObj>();
    var blist = new List<BObj>();
    // .. objects initialized here, plugged into respective lists, etc.
    var temp_list = new List<IEnumerable<object>>();
    temp_list.Add(alist);
    temp_list.Add(blist);
    foreach (var v in temp_list)
    {
        foreach (var x in v)
        {
            
        }
    }
