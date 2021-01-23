    var ilist = list as IList;
    if (ilist != null)
    {
        for (int i = 0; i < ilist.Count; i++)
        {
            ilist[i] = "new value";
        }
    }
