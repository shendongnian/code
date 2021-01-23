    var model = _db2.Persons.Select(x => x.Id)
                            .ToList() // return int[]
                            .Select((id, index) => new
                                    {
                                        rn = index + 1,
                                        col1 = id
                                     }) // return anonymous[] (with rn and col1)
                             .AsEnumerable(); // get an IEnumerable (readonly collection)
