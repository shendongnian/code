    List<RegionViewModel> regionList = (from rs in db.Regions   
                                       select new RegionViewModel
                                       {
                                          RegionId = rs.RegionId.ToString(),
                                          RegionName = rs.RegionName
                                       }).ToList();
    ViewBag.Regions = new SelectList(regionList, "RegionId", "RegionName", "E81D6D99-D4A8-4806-8718-B8552EA90FD2");
