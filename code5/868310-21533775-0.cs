    var query = items.Where(i => i.userid == userId).GroupBy(i => i.originalid).Select(i => new
                        {
                            LatestItem = i.OrderByDescending(x => x.id).First(),
                            History = i.OrderByDescending(x => x.id).Skip(1).Select(x => new
                            {
                                id = x.id,
                                originalid = x.originalid
                            }).ToList()
                        }).ToList();
