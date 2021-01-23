    System.Timers.Timer timer1;
    
    
    timer1 = new System.Timers.Timer(2000);
    timer1.Enabled=false;
    timer1.Elapsed += new ElapsedEventHandler(timer1_Elapsed);
    void timer1_Elapsed(object sender, ElapsedEventArgs e)
            {
                lblsuccess.Visible = false;
                timer1.Enabled=false;
            }
    
     if (saved == true)
                {
                    //data saved - show label and then make visible = false
    
                    timer1.Enabled=true;
                    lblsuccess.Visible = true;
                    lblsuccess.Text = "Visit saved";
                 }
