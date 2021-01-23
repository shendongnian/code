    private void chart_AfterDraw(object sender, Steema.TeeChart.Drawing.Graphics3D g)
    {
    
    g.Font.Name = "Arial";
    g.Font.Color = UIColor.Red.CGColor;
    g.Font.Size = 18;
    
    g.TextOut(xpos, ypos, "label");
    }
