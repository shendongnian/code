    public Form1() {
      InitializeComponent();
      this.DoubleBuffered = true;
      this.ResizeRedraw = true;
    }
    protected override void OnPaintBackground(PaintEventArgs e) {
      base.OnPaintBackground(e);
      using (Image img = Image.FromFile(@"c:\...\roses.jpg")) {        
        Rectangle center = new Rectangle(this.ClientSize.Width / 2 - img.Width / 2,
                                         this.ClientSize.Height / 2 - img.Height / 2,
                                         img.Width, img.Height);
        using (TextureBrush tb = new TextureBrush(img)) {
          tb.WrapMode = WrapMode.TileFlipXY;
          tb.TranslateTransform(center.X, center.Y);
          e.Graphics.FillRectangle(tb, this.ClientRectangle);
        }
      }
    }
