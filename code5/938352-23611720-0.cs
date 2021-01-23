    //tab is selected
    System.Drawing.SolidBrush lightBlue = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(239, 242, 247));
    g.FillRectangle(lightBlue, tabRectangle);
    // I can't get this working..
    System.Drawing.SolidBrush sele = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(65, 95, 155));
    g.FillRectangle(sele, new System.Drawing.Rectangle(
         tabRectangle.X,tabRectangle.Y,
         5, 32));
