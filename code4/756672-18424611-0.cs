    private IList<Point> _pointList = new List<Point>();
    private void panel1_MouseMove(object sender, MouseEventArgs e)
    {    
        _pointList.Add( e.Location );
        panel1.Invalidate(); //force a repaint
    }
    
    private void panel1_Paint( object sender, PaintEventArgs e )
    {
        e.Graphics.DrawLines( Pens.Black, _pointList );
    }
