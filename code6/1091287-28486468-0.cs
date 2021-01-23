    List<string> outputList = new List<string>();
    foreach (var str in originalList)
    {
        if (!outputList.Contains(str)
            && !originalList.Any(r => r!= str && r.Contains(str)))
        {
            outputList.Add(str);
        }
    }
