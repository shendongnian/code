    var lstHotelLocation = hotellocation.GroupBy(x => x)
                                        .Where(g => g.Key != "")
                                        .Select(g => new HotelLocation {
                                            Name = kv.Key,
                                            count = g.Count()
                                        })
                                        .ToList();
     var lstHotelType = hoteltype.GroupBy(x => x)
                                 .Where(g => g.Key != "")
                                 .Select(g => new HotelTypeFilter {
                                     Name = g.Key,
                                     count = g.Value
                                 })
                                 .ToList();
