    private Bitmap b = null;
    private bool IsDragging = false;
    private Point down = Point.Empty;
    private Point offset = Point.Empty;
        
    private void button1_MouseUp(object sender, MouseEventArgs e)
    {
      IsDragging = true;
      button1.Visible = false;
      down = button1.PointToScreen(e.Location);
      offset = e.Location;
      this.Invalidate();
    }
        
    private void Form1_MouseUp(object sender, MouseEventArgs e)
    {
      if (IsDragging)
      {
        IsDragging = false;
        down = new Point(down.X - offset.X, down.Y - offset.Y);
        button1.Location = down;
        button1.Visible = true;
        down = Point.Empty;
        this.Invalidate();
      }
    }
        
    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
      if (IsDragging)
      {
        down.X += (e.X - down.X);
        down.Y += (e.Y - down.Y);                
        this.Invalidate();
      }
    }
        
    private void Form1_Load(object sender, EventArgs e)        
    {
      try
      {
        b = new Bitmap(button1.Width, button1.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
        button1.DrawToBitmap(b, new Rectangle(0, 0, button1.Width, button1.Height));
        button1.MouseUp += new MouseEventHandler(button1_MouseUp);                
        this.MouseUp += new MouseEventHandler(Form1_MouseUp);
        this.MouseMove += new MouseEventHandler(Form1_MouseMove);
        this.DoubleBuffered = true;
        this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
        this.UpdateStyles();
        this.BackgroundImage = Image.FromFile(@"C:\Users\Public\Pictures\Sample Pictures\desert.jpg");
        this.BackgroundImageLayout = ImageLayout.Stretch;
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }
        
    protected override void OnPaint(PaintEventArgs e)
    {
      if (IsDragging)
      {
        e.Graphics.DrawImage(b, new Point(down.X - offset.X, down.Y - offset.Y));
      }
      base.OnPaint(e);
    }
        
    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (b != null)
      {
        b.Dispose();
      }
    }
