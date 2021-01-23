     using (System.Drawing.Pen aPen = new Pen(Color.Firebrick, 5)) {
       aPen.DashStyle = DashStyle.Solid;
       // Paint with aPen here
       ...
     }
    
     using (System.Drawing.Pen bPen = new Pen(Color.Firebrick, 1)) {
       bPen.DashStyle = DashStyle.Dot;
       // Paint with bPen here
       ...
     }
  
