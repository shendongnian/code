    class MyToolStripContainer : System.Windows.Forms.ToolStripContainer
    {
        public MyToolStripContainer()
        {
            var rect = new Rectangle(0, 0, 300, 300);
            using (Bitmap bitmap = new Bitmap(rect.Height, rect.Width))
            using (Graphics graphics = Graphics.FromImage(bitmap))
            using (LinearGradientBrush brush = new LinearGradientBrush(
                rect,
                Color.Blue,
                Color.Red,
                LinearGradientMode.ForwardDiagonal))
            {
                brush.SetSigmaBellShape(0.5f);
                graphics.FillRectangle(brush, rect);
                ContentPanel.BackgroundImage = Image.FromHbitmap(bitmap.GetHbitmap());
            }
            ContentPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        }
    }
