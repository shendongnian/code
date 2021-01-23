    var results = users.Where(x => x.Id != userId &&
                                               !users.Where(v => v.Id == userId)
                                                     .SelectMany(v => v.Friends.Select(d => d.Id))
                                                     .Any(e => e == x.Id))
                                                     .Select(x=>new
                                                                    {
                                                                        //your projection
                                                                    })
                                   .ToList();
