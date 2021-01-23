    private void panelControlVennDiagram_Paint(object sender, PaintEventArgs e)
    {
        Brush brushLeft = new SolidBrush(Color.Blue);
        Brush brushRight = new SolidBrush(Color.LightPink);
        Brush brushCommon = new SolidBrush(Color.Purple);
        Pen pen = new Pen(brushLeft, 10);
        Rectangle leftVenn = new Rectangle(20, 50, 100, 100);
        Rectangle rightVenn = new Rectangle(90, 50, 100, 100);          
        //Font stringFont = new Font("Times New Roman", 9);
        //e.Graphics.DrawString("Left:" , stringFont, brushLeft, 10, 70);
        //e.Graphics.DrawString("Right:" , stringFont, brushRight, 90, 70);
        //e.Graphics.DrawString("Common:", stringFont, brushCommon, 100, 70);
        // Fill ellipse on screen.
        e.Graphics.FillEllipse(brushLeft, leftVenn);
        e.Graphics.FillEllipse(brushRight, rightVenn);
        e.Graphics.DrawEllipse(Pens.White, leftVenn);
        e.Graphics.DrawEllipse(Pens.White, rightVenn);
            
        Region region1 = new Region();
        using (GraphicsPath circle_path = new GraphicsPath())
        {
            circle_path.AddEllipse(leftVenn);
            region1.Intersect(circle_path);
        }
        using (GraphicsPath circle_path = new GraphicsPath())
        {
            circle_path.AddEllipse(rightVenn);
            region1.Intersect(circle_path);
        }
        e.Graphics.FillRegion(brushCommon, region1);
    }
