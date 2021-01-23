    foreach (string arg in searchWords)
    {
        if (arg == null || arg.Length < 1)
            continue;
        tempList = new List<T>();
        if (dictionary.ContainsKey(arg))
            foreach (T obj in dictionary[arg])
            if (list.Contains(obj))
                    tempList.Add(obj);
        list = new List<T>(tempList);
    }
