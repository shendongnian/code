    List<AObj> alist = new List<AObj>();
    List<BObj> blist = new List<BObj>();
    // .. objects initialized here, plugged into respective lists, etc.
    List<object> temp_list = new List<object>();
    temp_list.Add(alist);
    temp_list.Add(blist);
    var allObjects = temp_list
        .Select(l => l as IEnumerable<object>)  // try to cast to IEnumerable<object>
        .Where(l => l != null)                  // filter failed casts
        .SelectMany(l => l);                    // transform the list of lists into a single sequence of objects
    foreach (var o in allObjects)
    {
        // enumerates objects in alist and blist.
    }
