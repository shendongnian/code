    var dbObjects = new Dictionary<int, ObjectModel>();
    foreach(var y in dbObject)
    {
        dbObjects.Add(y.id, y);
    }
    foreach(var x in formObject)
    {
        ObjectModel y;
        if(dbObjects.TryGetValue(x.id, out y))
        {
            //compare each property and notify user of change if different
        }
    }
