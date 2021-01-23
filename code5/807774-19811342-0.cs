    IList list = dataObject as IList; // note: non-generic; you could also
                                      // use IEnumerable, but that has some
                                      // edge-cases; IList is more predictable
    if(list != null)
    {
        foreach(object obj in list)
        {
            strList.Add(obj.ToString());
        }
    }
