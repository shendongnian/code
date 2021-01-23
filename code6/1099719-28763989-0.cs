    Path p1; // filled with a polygon
    Path p2; // filled with another polygon
    
    PathGeometry pg1 = p1.RenderedGeometry.GetFlattenedPathGeometry();
    pg1.FillRule = FillRule.EvenOdd;
    
    PathGeometry pg2 = p2.RenderedGeometry.GetFlattenedPathGeometry();
    pg2.FillRule = FillRule.EvenOdd;
    
    IntersectionDetail id = pg1.FillContainsWithDetail(pg2);
    if (id == IntersectionDetail.FullyContains) // now reached as expected
    if (id == IntersectionDetail.FullyInside) // now reached as expected
    if (id == IntersectionDetail.Intersect)
    if (id == IntersectionDetail.Empty)
