    List<string> combined = new List<string>();
    string separator = new string(' ', 20);
    int count = stringList.Count >= doubleList.Count ? stringList.Count : doubleList.Count;
    for (int i = 0; i < count; i++)
    {
        combined.Add(string.Format("{0}{1}{2}", stringList.Count <= i ? "" : stringList[i]
                                              , separator
                                            , doubleList.Count <= i ? "" : doubleList[i].ToString()));
    }
