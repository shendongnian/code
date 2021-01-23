    int index = 0;
    var query = selectedPlaylists
                  .SelectMany(p => p.StreamFiles
                                   .Select(s =>
                                              new {
                                                    PlayList = p,
                                                    Index = index++,
                                                    StreamFile = s
                                                  }));
