    protected void check_Answer(object sender, EventArgs e)
    {
        string grpId = ((RadioButton)sender).GroupName;
        string  questionId = grpId.Split('_')[1].ToString();
               
        Session["test"] = questionId;/*Just added to a session and passed to test page*/
        Response.Redirect("test.aspx");/*This Page Displays the value of Session["test"]*/
    }
