    protected void btn_submit_Click(object sender, EventArgs e)
    {
        // Maybe validation?
        Submit();
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        DateTime et = DateTime.Parse(Session["endtime"].ToString());
    
        if (DateTime.Now.TimeOfDay >= et.TimeOfDay)
        {
            Submit();
            Response.Redirect("Welcome.aspx");
        }
        else
        {
            Label1.Text = DateTime.Now.ToLongTimeString();
        }
    }
    private void Submit()
    {
        // Common code to execute on either the timer tick or button click
    }
