    private void canvas1_Paint( object sender, PaintEventArgs e )
    {
        // do your painting here, using the Graphics object passed to
        // you in the PaintEventArgs
        Pen penMin = new Pen( Color.Pink, 2 );
        Pen penH = new Pen( Color.Red, 3 );
        Pen penSec = new Pen( Color.DeepPink, 1 );
        Pen black = new Pen( Color.Black, 4f );
        e.Graphics.TranslateTransform( 250, 250 );
        e.Graphics.DrawEllipse( black, -220, -220, 440, 440 );
        e.Graphics.ResetTransform();
        e.Graphics.TranslateTransform( 250, 250 );
        e.Graphics.RotateTransform( 6 * DateTime.Now.Minute );
        e.Graphics.DrawLine( penMin, 0, 0, 0, -200 );
        e.Graphics.ResetTransform();
        e.Graphics.TranslateTransform( 250, 250 );
        e.Graphics.RotateTransform( 30 * DateTime.Now.Hour );
        e.Graphics.DrawLine( penH, 0, 0, 0, -120 );
        e.Graphics.ResetTransform();
        e.Graphics.TranslateTransform( 250, 250 );
        e.Graphics.RotateTransform( 6 * DateTime.Now.Second );        
        e.Graphics.DrawLine( penSec, 0, 0, 1, -180 );
    }
