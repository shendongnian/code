    List<DevelopmentType> devTypes = 
               defaults.Select(dc => dc.DevelopmentType)
                       .Include(d => d.DefaultCharges)
                       .Include(d => d.OverrideCharges)
                       .Select(x => {
                            var tmp = x;
                            // assuming you have some property to hold your Zones selection
                            tmp.Zones = tmp.OverrideCharges
                                              .Where(oc => oc.ChargingScehdule_RowId == cs.RowId)
                                              .Select(oc => oc.Zone)
                            return tmp;
                       })
                       .ToList();
