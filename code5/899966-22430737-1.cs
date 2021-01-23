         //..
         // making the line dynamic, a little
        g.DrawLine(pen, new Point(LinePointX, 80), new Point(LinePointX + LineLength, 80));
        }
        // keeping state of the line..
       int LinePointX = 50; int LineLength = 400;
        // and the mouse movement..
       int lastX = 0; int currentX = 0; 
       private void panel1_MouseDown(object sender, MouseEventArgs e)
       {
           // hittest omitted
           lastX = currentX;
           currentX = e.X;
       }
       private void panel1_MouseUp(object sender, MouseEventArgs e)
       {
           // hittest omitted
           lastX = currentX;
           currentX = e.X;
           LinePointX += (currentX - lastX);
           // making the paint event refresh the line area and then some..
           panel1.Invalidate(new Rectangle(0, 70, panel1.Width, 20));
       }
       private void panel1_MouseMove(object sender, MouseEventArgs e)
       {
           if (e.Button == System.Windows.Forms.MouseButtons.Left)
           {
               lastX = currentX;
               currentX = e.X;
               LinePointX += currentX - lastX;
               // making the paint event refresh the line area and then some..
               panel1.Invalidate(  new Rectangle(0 , 70, panel1.Width, 20));
           }
       }
