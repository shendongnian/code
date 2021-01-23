    int externalStatusID = 5;
    InternalStatus internalStatus;
    if (_map.TryGetValue(externalStatusID, out internalStatus)) {
        Console.WriteLine("Internal status ID = {0}, Name = {1}",
            internalStatus.ID, internalStatus.Name);
    } else {
        Console.WriteLine("Status not found!");
    }
