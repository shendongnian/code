    public static  class VectorLayerHelperExtensions
    {
        public static IEnumerable<OgrEntity> Reduce(this IQueryable<OgrEntity> query, double threshold)
        {
            return query.Select(s => new
                      {
                          g = SqlSpatialFunctions.Reduce(s.Geometry, threshold),
                          s
                      }).AsEnumerable().Select(t => { t.s.Geometry = t.g; return t.s; });
        }
    }
