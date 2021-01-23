    System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
    timer1.Interval=1000;//one second
    timer1.Tick += new System.EventHandler(timer1_Tick);
    timer1.Start();
    int count=30;
    private void timer1_Tick(object sender, EventArgs e)
    {
       if(count!=0)
       {
       button1.Enabled=false;
       label1.Text =  count.ToString() +" seconds more to Enable Refresh Button";
       count--;
       }
       else
       {
       button1.Enabled=true;
       timer1.Stop();
       }
    }
