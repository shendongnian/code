    foreach (string arg in searchWords)
    {
        if (String.IsNullOrEmpty(arg))
            continue;
        tempList = new List<T>();
        if (dictionary.ContainsKey(arg))
            foreach (T obj in dictionary[arg])
            if (list.Contains(obj))
                    tempList.Add(obj);
        list = new List<T>(tempList);
    }
