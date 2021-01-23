        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath Shape1 = new GraphicsPath();
            Shape1.AddRectangle(new Rectangle(e.ClipRectangle.X + (e.ClipRectangle.Width - 40) / 2, e.ClipRectangle.Y, 40, e.ClipRectangle.Height));
            GraphicsPath Shape2 = new GraphicsPath();
            Shape2.AddRectangle(new Rectangle(e.ClipRectangle.X, e.ClipRectangle.Y + (e.ClipRectangle.Height - 40) / 2, e.ClipRectangle.Width, 40));
            Region UnitedRegion = new Region();
            UnitedRegion.MakeEmpty();
            UnitedRegion.Union(Shape1);
            UnitedRegion.Union(Shape2);
            e.Graphics.FillRegion(Brushes.Black, UnitedRegion);
        }
