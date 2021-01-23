    Context.Candies
                    .Where(c => c.Id == c.CandyRegions
                        .FirstOrDefault(cr => cr.RegionId == c.CandyRegions
                            .GroupBy(grp => grp.RegionId)
                                .Select(r => new
                                                {
                                                    RegionId = r.Key,
                                                    Total = r.Count()
                                                }
                                        ).OrderByDescending(r => r.Total)
                                                    .Take(1)
                                                    .First().RegionId).CandyId
                            )
                            .ToList();
