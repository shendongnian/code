    private void BtnSend_Click(object sender, EventArgs e)
    {
       try
       {			
        	BackgroundWorker SendMail = new BackgroundWorker()
        	{
        	    WorkerSupportsCancellation = true
        	};
        				
        	SendMail.DoWork += SendMail_DoWork;
        	SendMail.RunWorkerCompleted += SendMail_RunWorkerCompleted;
        
        	TimrSending.Start();
        	OleDbDataReader hold = cdbc.connectDB("SELECT UserID, PassWord, EmailID from Tbl_RegisteredUser where UserID='" + TxtUserID.Text + "' and AF=true");
        	hold.Read();
        
        	List<string> parameters = new List<string>() {hold[0].ToString(), hold[1].ToString(), hold[2].ToString()};
        	SendMail.RunWorkerAsync(parameters);
        }
        			
        catch (Exception)
        {
            cdbc.disconectDB();
            this.TimrSent.Stop();
            BtnSend.Text = "Send";
            MessageBox.Show("Message sending failed! \n Exeption" + e.ToString(), "Email Failure", MessageBoxButtons.OK); 
        }
    }
        
    private void SendMail_DoWork(object sender, DoWorkEventArgs e)
    {
        List<string> args = (List<string>) e.Argument;
        try
        {
            SendMailNew(args[0], args[1], args[2]);
    			
            e.Result = true;
        }
        catch(Exception ex)
        {
            e.Result = false;
        }
    }
        		
    void SendMail_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {                
        if(e.Result)
        {
    	    cdbc.disconectDB();
    	    MessageBox.Show("Message sent successfully! \n Please check your registered Email address for the password");
    	    cdbc.disconectDB();
    	    this.Close();
    	    //Application.DoEvents();
    	    this.TimrSending.Stop();
        }
        else
        {
            // Fail
        }		 
    }
        
    private void TimrSending_Tick(object sender, EventArgs e)
    {
         BtnSend.Text = flag ? "Sending" : "..Sending..";
         flag = !flag;
    }
