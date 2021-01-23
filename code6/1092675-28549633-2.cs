    float zoom = 7.5f;
    public Form1()
    {
        InitializeComponent();
        pb1.SizeMode = PictureBoxSizeMode.Zoom;
        pb1.ClientSize = new Size((int) (pb1.Image.Size.Width  * zoom), 
                                  (int) (pb1.Image.Size.Height * zoom) );
    }
    private void pb1_MouseClick(object sender, MouseEventArgs e)
    {
       int x = (int)Math.Round(e.X / zoom) ;
       int y = (int)Math.Round(e.Y / zoom) ;
       Bitmap bmp = (Bitmap) pb1.Image;
       bmp.SetPixel(x, y, Color.Red);
       pb1.Refresh();
    }
