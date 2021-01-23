    public Form1()
    {
       InitializeComponent();
       pictureBox1.Image = new Bitmap(pictureBox1.ClientSize.Width, 
                                      pictureBox1.ClientSize.Height); 
       Graphics graphics = Graphics.FromImage(pictureBox1.Image);
       graphics.FillRectangle(Brushes.CadetBlue, 0, 0, 99, 99);
       graphics.FillRectangle(Brushes.Beige, 66, 55, 66, 66);
       graphics.FillRectangle(Brushes.Orange, 33, 44, 55, 66);
    }
