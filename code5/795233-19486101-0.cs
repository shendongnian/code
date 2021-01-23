    var items = gameReports.SelectMany(g => g.Entries
                                            .Select(e => new
                                                         { 
                                                             g.GameName,
                                                             Entry = e
                                                         })).ToList();
