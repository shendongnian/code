    static List<T> AssembleCounts<T>(IEnumerable<string> values, 
                                     Func<string, int, T> makeObject)
    {
        return values.GroupBy(x => x)
                     .Where(g => g.Key != "")
                     .Select(g => makeObject(g.Key, g.Count()))
                     .ToList();
    }
    var lstHotelLocation = AssembleCounts(hotellocation,
                                          (k, c) => new HotelLocation {
                                              Name = k, count = c
                                          });
    var lstHotelType = AssembleCounts(hoteltype,
                                          (k, c) => new HotelTypeFilter {
                                              Name = k, count = c
                                          });
