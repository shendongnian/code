    protected void cbPop_CheckedChanged(object sender, EventArgs e)
    {
        Response.Cookies["UserPreferences"].Value = 
           Request.Cookies["UserPreferences"].Value + "1";
        Label1.Text = Response.Cookies["UserPreferences"].Value.Length.ToString();
        //                ^
        //                |
    }
    
    protected void cbDown_CheckedChanged(object sender, EventArgs e)
    {
        Response.Cookies["UserPreferences"].Value = 
            Request.Cookies["UserPreferences"].Value + "2";
        Label1.Text = Response.Cookies["UserPreferences"].Value.Length.ToString();
        //                ^
        //                |
    }
