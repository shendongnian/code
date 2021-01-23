    private Region FindIntersections(List<PolyRegion> regions)
    {
        if (regions.Count < 1) return null;
    
        Region region = new Region();
        for (int i = 0; i < regions.Count; i++)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddPath(regions[i].Path, false);
                region.Intersect(path);
            }
        }
    
        return region;
    }
