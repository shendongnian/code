    var maxCap = pCapacity + 20;
    var query = sampleDB.Spaces
              .Where(r => r.roomCapacity >= pCapacity && r.roomCapacity <= maxCap);
    if(pBeamer)
        query = query.Where(r => r.roomBeamer);
    if(pCapacity)
        query = query.Where(r => r.roomCapacity);
    // ...
    var rooms = query.Select(r => new RoomViewModel() //...);
