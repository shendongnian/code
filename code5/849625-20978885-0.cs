    protected void Timer1_Tick(object sender, EventArgs e)
    		{
    		Output_lbl.Text+=Session["Text"].ToString();    		
                    }
    protected void OutputReceived(object sender, DataReceivedEventArgs e)
        {
        Session["Text"]+=e.Data;
        System.Diagnostics.Debug.WriteLine(Text);
        }
