    private void form_load(object sender, EventArgs e)
    {
    	System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
    	timer.Interval = 1000;
    	timer.Enabled = true;
    }
    
    private void timer_tick(object sender, EventArgs e)
    {
    	label5.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
    	label3.Text = System.DateTime.Now.ToString("hh:mm:ss tt");
    }
