    protected void yourButton_Click(Object sender, EventArgs e)
    {
        if (!this.IsRequestAlreadyProcessed)
        {
            this.IsRequestAlreadyProcessed = true;
            //Carry out all your SQL Agent Job operations here...
            Response.Redirect("~/ToYourPage2.aspx");
        }
    }
