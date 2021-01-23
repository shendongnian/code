    bans = bans.Where(b => ( string.IsNullOrWhiteSpace(filter.GroupName) || b.GroupName == filter.GroupName )
                            &&
                            ( ( string.IsNullOrWhiteSpace(filter.Nick) || b.Nick == filter.Nick )
                              ||
                              ( string.IsNullOrWhiteSpace(filter.IP) || b.IP == filter.IP )
                            )
                     );
