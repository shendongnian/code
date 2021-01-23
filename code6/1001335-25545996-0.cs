     private void panel1_Paint(object sender, PaintEventArgs e)
      {
         using (Pen pen = new Pen(Brushes.Crimson))
            {
                e.Graphics.DrawLine(pen, 200, 200, counter, 300);                
            }
      }
     private void timer1_Tick(object sender, EventArgs e)
      {            
          counter++;
          if (counter >= 10)
              timer1.Stop();
          lblCountDown.Text = counter.ToString();
          panel1.Invalidate();           
      }
   
