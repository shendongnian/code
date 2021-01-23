    class ShapedControl : Panel
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.Clear(this.BackColor);
            Rectangle rect1 = new Rectangle(20, 20, 200, 200);
            Rectangle rect2 = new Rectangle(70, 70, 100, 100);
            GraphicsPath gp1 = new GraphicsPath();
            GraphicsPath gp2 = new GraphicsPath();
            gp1.AddPie(rect1, 0, 90);
            gp2.AddPie(rect2, 0, 90);
            Region rg1 = new System.Drawing.Region(gp1);
            Region rg2 = new System.Drawing.Region(gp2);
            g.DrawPath(Pens.Transparent, gp1);
            g.DrawPath(Pens.Transparent, gp2);
            rg1.Xor(rg2);
            g.FillRegion(Brushes.Black, rg1);
            this.Region = rg1;
        }
        //Just for testing purpose. Place a breakpoint
        //in here and you'll see it will only get called when
        //you click inside the "pie" shape
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
        }
    }
