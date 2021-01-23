    PathGeometry geometry = combinedGeometry.GetFlattenedPathGeometry();
    Console.WriteLine(geometry.ToString());
            
    foreach (PathFigure figure in geometry.Figures)
    {
         Console.WriteLine(figure.StartPoint);
         foreach (PathSegment segment in figure.Segments)
         {
             foreach (Point point in ((PolyLineSegment)segment).Points)
             {
                 Console.WriteLine(point);
             }
         }
     }
