        using System.Drawing;    
        Graphics g;
        using (g = Graphics.FromHwnd(IntPtr.Zero))
             
            {
                     
                 g.DrawEllipse(Pens.Red, x,y, 20, 20);
                                                
             }
