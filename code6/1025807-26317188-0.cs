    var t = ctx.Layer
    .Where(c => c.Geometry.Intersects(boundingBox))
    .Select(s => new
    {
      Geometry = SqlSpatialFunctions.Reduce(s.Geometry, degreesPerPixel),
      Layer = s
    }).ToArray();
