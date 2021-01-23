    var tempDict = new Dictionary<string, MyClass>();
    foreach (var data in list) // list is the List<MyClass>
    {
        MyClass existing;
        if (!tempDict.TryGetValue(data.ParentId, out existing))
        {
            // Put item into temp dictionary (use ParentId as key)
            tempDict[data.ParentId] = data;
        }
        else
        {
            // Check if the instance in the temp dictionary has an
            // earlier EndDate. If yes, replace it.
            if (existing.EndDate < data.EndDate) // replace
                tempDict[data.ParentId] = data;
        }
    }
    var result = tempDict.Values.ToList();
