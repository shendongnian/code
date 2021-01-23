	protected override void OnRender(System.Windows.Media.DrawingContext dc)
	{
		var pen = new System.Windows.Media.Pen(System.Windows.Media.Brushes.Black, 2);
		for (int i = 0; i < _numberOfColumns; i++)
		{
			double x = (i + 1) * _columnWidth;
			dc.DrawLine(pen, new Point(x, 0), new Point(x, 1000));
		}
		base.OnRender(dc);
	}
