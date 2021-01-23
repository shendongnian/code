    public Form1()
    {
        InitializeComponent();
        pictureBox1.Image = Bitmap.FromFile(your1stImage);
        bmp = (Bitmap)Bitmap.FromFile(your2ndImage);
        pb2.Parent = pictureBox1;
        pb2.Size = new Size(10,10);
    }
    Bitmap bmp;
    PictureBox pb2 = new PictureBox();
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        Point tLocation =   new Point(e.Location.X - pb2.ClientSize.Width, 
                                      e.Location.Y - pb2.ClientSize.Height);
        Rectangle r1 = new Rectangle(tLocation, pb2.ClientSize);
        Rectangle r2 = pb2.ClientRectangle;
        using (Graphics G = pb2.CreateGraphics() )
        {
            G.DrawImage(bmp, r2, r1, GraphicsUnit.Pixel);
        }
        pb2.Location = tLocation;
    }
