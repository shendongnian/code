    private System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
    private void startThread() {
             myTimer.Tick += new EventHandler(timerEvent);
             myTimer.Interval = 30;
             myTimer.Start();
         }
     private void timerEvent(object sender, EventArgs e)
         {
               var it = labels.GetEnumerator();
               while (it.MoveNext())
            
             {
                 Label lb = it.Current;
                // Label lb = labels.ElementAt(b);
                 if (lb.Location.X + lb.Width < 0)
                 {
                     this.Controls.Remove(lb);
                     if (labels.Count > 1)
                        lb.Location = new Point(lastLb.Right, 0);
                     else
                         lb.Location = new Point(2000, 0);
                     lastLb = lb;
                      this.Controls.Add(lb);
                     this.Refresh();
                 }
                 if (leftLb != null)
                     if (leftLb.Location.X + leftLb.Width - lb.Location.X < -20)
                         lb.Location = new Point(leftLb.Right, 0);
                     else
                        lb.Location = new Point(lb.Location.X - 3, lb.Location.Y);
                 leftLb = lb;
             }
     }
