    var query = selectedPlaylists
                  .SelectMany((p, i) => p.StreamFiles
                                   .Select(s =>
                                              new {
                                                    PlayList = p,
                                                    Index = i,
                                                    StreamFile = s
                                                  }));
