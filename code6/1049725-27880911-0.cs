    ilPanel1.Scene.MouseClick += (_s, _a) => {
        if (_a.DirectionUp) return; 
        var lp = ilPanel1.Scene.First<ILLinePlot>();
        if (lp != null) {
            if (lp.Marker.Style == MarkerStyle.TriangleDown) {
                lp.Marker.Style = MarkerStyle.Rectangle;
                lp.Marker.Fill.Color = Color.White;
            } else {
                lp.Marker.Style = MarkerStyle.TriangleDown;
                lp.Marker.Fill.Color = Color.Red; 
            }
            lp.Configure();
            ilPanel1.Refresh(); 
        }
    }; 
