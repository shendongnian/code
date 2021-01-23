    var entities = from row in table.AsEnumerable()
                   let tmp = GetObjectByProcessingID(row.ID)
                   select new {
                                ID = row.ID,
                                X = tmp[0],
                                Y = tmp[1],
                                ....
                               };
