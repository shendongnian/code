    private string _previous;
    private void mapBox1_MouseMove(GeoAPI.Geometries.Coordinate worldPos, MouseEventArgs imagePos)
    {
        var text = ...; // generate tooltip text based on the new position
        if(text != _previous)
        {
            _previous = text;
            tooltip.Show(text, mapBox1, mapBox1.PointToClient(imagePos.Location)); 
        }
    }
    private void mapBox1_MouseLeave(object sender, EventArgs e)
    {
        toolTip.Hide(mapBox1);
    }
