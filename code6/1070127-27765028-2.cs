    private void canvas1_Paint( object sender, PaintEventArgs e )
    {
        // do your painting here, using the Graphics object passed to
        // you in the PaintEventArgs
        // example
        e.Graphics.Clear( Color.White );
        e.Graphics.DrawRectangle( Pens.Red, 10, 10, 50, 50 );
    }
