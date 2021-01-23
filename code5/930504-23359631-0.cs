    public Form1()
    {
    	InitializeComponent();
    
    	Bitmap myBitmap = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
    
    	using (Graphics g = Graphics.FromImage(myBitmap))
    	{
    		g.Clear(Color.Aqua);
    		g.DrawRectangle(new Pen(Brushes.Black), 10, 10, 100, 100);
    	}
    
    	this.pictureBox1.Image = myBitmap;
    }
