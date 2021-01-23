    public Form1()
    {
        InitializeComponent();
        pictureBox1.Image = Bitmap.FromFile(your1stImage);
        bmp = (Bitmap)Bitmap.FromFile(your2ndImage);
        pb2.Parent = pictureBox1;
        pb2.Size = new Size(10,10);
        /* this is for fun only: If restricts the overlay to a circle: 
        GraphicsPath gp = new GraphicsPath();
        gp.AddEllipse(pb2.ClientRectangle);
        pb2.Region = new Region(gp);
        */
    }
    Bitmap bmp;
    PictureBox pb2 = new PictureBox();
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        Rectangle rDest= pb2.ClientRectangle;
        Point tLocation =   new Point(e.Location.X - rDest.Width - 5, 
                                      e.Location.Y - rDest.Height - 5);
        Rectangle rSrc= new Rectangle(tLocation, pb2.ClientSize);
        using (Graphics G = pb2.CreateGraphics() )
        {
            G.DrawImage(bmp, rDest, rSrc, GraphicsUnit.Pixel);
        }
        pb2.Location = tLocation;
    }
