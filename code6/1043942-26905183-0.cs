    public static IEnumerable<Region> GetNeighborhoods(Region region)
    {
        if 
        (
            region.RegionType == "Country" || 
            region.RegionType == "Multi-Region (within a country)" || 
            region.RegionType == "City" ||
            region.RegionType == "Multi-City (Vicinity)" || 
            region.RegionType == "Province (State)" || 
            region.RegionType == "Multi-Region (within a country)"
        )
        {
            foreach (var child in region.GetChildren())
                foreach (var region in GetNeighborhoods(child))
                    yield return region;
        }
        else
        {
            var ctx = new DalContext();
            var matchingRegions = ctx.Regions.Where(r => 
                r.ParentRegionId == region.ParentRegionId && 
                r.RegionType == "Neighborhood" &&
                r.RegionNameLong.Contains(region.RegionName) && 
                r.Id != region.Id
            );
            foreach (var region in matchingRegions)
                yield return region;
        }
    }
