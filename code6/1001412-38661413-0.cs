	public static void DrawPolygon(this DrawingContext context, Brush brush, Pen pen, IEnumerable<Point> exteriorRing, IEnumerable<IEnumerable<Point>> interiorRings = null)
	{
		StreamGeometry geo = new StreamGeometry();
		Geometry finalGeometry = geo;
		using (StreamGeometryContext ctxExterior = geo.Open())
		{
			ctxExterior.BeginFigure(exteriorRing.First(), (brush != null), true);
			ctxExterior.PolyLineTo(exteriorRing.Skip(1).ToArray(), (pen != null), false);
			if (interiorRings != null)
			{
				foreach (var ring in interiorRings)
				{
					var interiorGeometry = new StreamGeometry();
					using (var ctxInterior = interiorGeometry.Open())
					{
						ctxInterior.BeginFigure(ring.First(), true, true);
						ctxInterior.PolyLineTo(ring.Skip(1).ToArray(), (pen != null), false);
					}
					finalGeometry = new CombinedGeometry(GeometryCombineMode.Exclude, finalGeometry, interiorGeometry);
				}
			}
		}
		context.DrawGeometry(brush, pen, finalGeometry);
	}
