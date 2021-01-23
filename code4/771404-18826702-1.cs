    path.Data = Geometry.Parse(CurrentObject.Geometry1);
    PathGeometry g = path.Data.GetFlattenedPathGeometry();
    PathGeometry g = path.Data.GetFlattenedPathGeometry();
    foreach (var f in g.Figures)
    {
  	Point pt1 = f.StartPoint;
  	pt1.X = pt1.X * ScaleX;
  	pt1.Y = pt1.Y * ScaleY;
  	strGeom += "M" + pt1.ToString();
        foreach (var s in f.Segments)
        if (s is PolyLineSegment)
        {
  			count = 0;
            foreach (var pt in ((PolyLineSegment)s).Points)
		{
        	int scount = ((PolyLineSegment)s).Points.Count;
		  	if (count == 0)
		  	{
		  		Point pts = new Point(pt.X * ScaleX, pt.Y * ScaleY);
			  	strGeom += "L" + pts.ToString();
		  	}
		  	else if (count < scount)
		  	{
		  		Point pts = new Point(pt.X * ScaleX, pt.Y * ScaleY);
			  	strGeom += " " + pts.ToString();
		  	}
		  	else if (count == scount)
		  	{
		  		Point pts = new Point(pt.X * ScaleX, pt.Y * ScaleY);
			  	strGeom += " " + pts.ToString() + "Z";
		  	}
		  	count++;
		}
        }
    }
    path.Data = Geometry.Parse(strGeom);
 
