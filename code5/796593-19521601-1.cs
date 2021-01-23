    var entities = table.AsEnumerable()
                        .Select(row => {
                           var tmp = GetObjectByProcessingID(row.ID);
                           return new {
                                    ID = row.ID,
                                    X = tmp[0],
                                    Y = tmp[1],
                                    ....
                                  };
                         });
