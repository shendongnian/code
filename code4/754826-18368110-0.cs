    var newList = new List<string>(names.Count + businessNames.Count);
    newList.AddRange(names); // will perform `Array.Copy` on underlying array //
    foreach (BusinessName name in businessNames) {
        newList.Add(name.Name);
    }
    names = newList; // replace old list with a new one //
