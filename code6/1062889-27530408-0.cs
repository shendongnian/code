    class ShapedPictureBox : PictureBox
    {
        public ShapedPictureBox()
        {
        this.Invalidated+=this.updateShape;
        }
    
        public Color transparentColor = Color.White;
    
        private void updateShape(object sender, InvalidateEventArgs e)
        {
        if(this.Image = null) return;
        Bitmap bitmap = new Bitmap(this.Image);
        System.Drawing.Drawing2D.GraphicsPath graphicsPath = new System.Drawing.Drawing2D.GraphicsPath();
        for(int x = 0; x < this.Image.Width; x++)
            for(int y = 0; y < this.Image.Height; y++)
                if(transparentColor != bitmap.GetPixel(x, y))
                    graphicsPath.AddRectangle(new Rectangle(new Point(x, y), new Size(1, 1)));
        this.Region = new Region(graphicsPath);
        }
    }
