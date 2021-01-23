    var parts1 = Keys.Select(k => k.Part1).ToArray();
    var parts2 = Keys.Select(k => k.Part2).ToArray();
    
    var dbSelection = context.TableRecords.Where(r => parts1.Contains(r.Part1)
                                                   && parts2.Contains(r.Part2);
    var finalSelection = from record in dbSelection
                                        .AsEnumerable() // to memory
                         join key in Keys on new { record.Part1, record.Part2 }
                                             equals
                                             new { key.Part1, key.Part2 }
                         select record;
