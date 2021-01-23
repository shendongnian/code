    List<int> ids = ... // Deserialized IDs.
    var tilemap = new List<Tile>(ids.Count);
    for (int i = 0; i < ids.Count; i++) {
        tilemap.Add(tileDict[ids[i]];
    }
    
