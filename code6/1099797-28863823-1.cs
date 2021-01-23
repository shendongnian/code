    public IEnumerable<Church> GetInBox(DbGeography boundingBox)
    {
      All().Where(c =>
                c.Lat <= nelt &&
                c.Lat >= swlt &&
                c.Lng <= nelng &&
                c.Lng >= swlng
                );
    }
