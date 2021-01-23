    System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
    timer1.Interval=60000;//one minute
    timer1.Tick += new System.EventHandler(timer1_Tick);
    timer1.Start();
    
    private void pictureBox1_Click(object sender, EventArgs e)
    {       
    	timer1.Stop();
    	timer1.Start();
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
    	//do whatever you want            
    	pictureBox2.Visible = false;
    }
