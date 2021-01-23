    private void panelControlVennDiagram_Paint(object sender, PaintEventArgs e)
    {
        Rectangle leftVenn = new Rectangle(20, 50, 100, 100);
        Rectangle rightVenn = new Rectangle(90, 50, 100, 100);          
        Region region1 = new Region();
        //Font stringFont = new Font("Times New Roman", 9);
        //e.Graphics.DrawString("Left:" , stringFont, brushLeft, 10, 70);
        //e.Graphics.DrawString("Right:" , stringFont, brushRight, 90, 70);
        //e.Graphics.DrawString("Common:", stringFont, brushCommon, 100, 70);
        // Fill ellipse on screen.
        using(Brush brushLeft = new SolidBrush(Color.Blue))
        {    
            e.Graphics.FillEllipse(brushLeft, leftVenn);
            e.Graphics.DrawEllipse(Pens.White, leftVenn);
        }
        using(Brush brushRight = new SolidBrush(Color.LightPink))
        {
            e.Graphics.FillEllipse(brushRight, rightVenn);        
            e.Graphics.DrawEllipse(Pens.White, rightVenn);
        } 
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
        using(Brush brushCommon = new SolidBrush(Color.Purple))
        {  
            e.Graphics.FillRegion(brushCommon, region1);
        }
         
    }
