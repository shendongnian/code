     System.Drawing.Pen myPen;
     myPen = new System.Drawing.Pen(System.Drawing.Color.Red);
     System.Drawing.Graphics formGraphics = this.CreateGraphics();
     formGraphics.DrawLine(myPen, 0, 0, 200, 200);
     myPen.Dispose();
     formGraphics.Dispose();
