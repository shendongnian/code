    List<ZipCodeTerritory> previousZips = allRecords.Where(
                                            z => (item.ZipCode.Equals(null)
                                            ? z.StateCode.Equals(item.StateCode) &&
                                            z.ChannelCode.Equals(item.ChannelCode) &&
                                            z.EndDate.Date == item.EndDate.Date
                                            : z.StateCode.Equals(item.StateCode) &&
                                            z.ChannelCode.Equals(item.ChannelCode) &&
                                            z.EndDate.Date == item.EndDate.Date &&
                                            (z.ZipCode.Equals(null) || z.ZipCode.Equals(item.ZipCode))
                                        )
                                ).ToList();
