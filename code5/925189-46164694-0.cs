                var queryResults = query
                    .Select(
                        g => new
                        {
                            g.Id,
                            g.Latitude,
                            g.Longitude,
                            ParentId = (long?)g.ParentObj2Objs.FirstOrDefault().ParentId
                        })
                    .ToList();
