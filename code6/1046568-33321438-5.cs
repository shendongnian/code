    protected override void OnRender(System.Windows.Media.DrawingContext dc)
    {
        if (Gaps != null && Gaps.Count > 0)
        {
            Geometry newGeometry = new RectangleGeometry(new Rect(0, 0, ActualWidth, ActualHeight));
            foreach (var gap in Gaps)
                // remove each rectangle  of the global clipping rectangle :
                // we make "a hole in the ice"
                newGeometry = Geometry.Combine(newGeometry, 
                    new RectangleGeometry(gap), 
                    GeometryCombineMode.Exclude, 
                    transform: null);
            // When the geometry is finished, we make the hole
            dc.PushClip(newGeometry);
        }
        dc.DrawRectangle(Background, null, new Rect(0, 0, ActualWidth, ActualHeight));
    }
   
