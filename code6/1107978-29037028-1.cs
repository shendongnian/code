    public Form1()
    {
       InitializeComponent(); 
       Bitmap bmpCheck2 = new Bitmap(2, 2);   
       bmpCheck2.SetPixel(0, 0, Color.FromArgb(127, 127, 127, 0));
       panel2.BackgroundImage = bmpCheck2;
       panel2.BackgroundImageLayout = ImageLayout.Tile;
       //..
     }
