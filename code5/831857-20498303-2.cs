    System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
    timer1.Interval=1000;//one second
    timer1.Tick += new System.EventHandler(timer1_Tick);
    timer1.Start();
    
    private void timer1_Tick(object sender, EventArgs e)
    {
         //Call the Button1 Click Event Handler
         button1_Click(sender,e);
         //Stop Timer whenever you want.
         //timer1.Stop(); 
    }
