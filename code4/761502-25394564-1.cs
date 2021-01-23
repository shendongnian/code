    //declare graphics globally
    Graphics g; 
    private void Form_Load(object sender, EventArgs e)
    {
        picCanvas.Image = new Bitmap(picCanvas.Width, picCanvas.Height);
        // create the graphics object here and not in DrawLine, which 
        // may cause flicker each time its instantiated
        graphics = Graphics.FromImage(picCanvas.Image);
        DrawLine();
    }
    
    private void DrawLine()
    {
        
        //Do not recreate the Graphics object here. 
        //Recreating it seems to 'erase' the existing image
        //Which causes flicker that double-buffering can't manage
        
        System.Drawing.Pen pen;
        pen.Color = Color.Black;
        // If you create the graphics object from the bitmap, this
        // should paint to the bitmap, so the Image object won't be null
        g.DrawLine(1, 1, picCanvas.Width - 2, picCanvas.Height - 2);   
    }
