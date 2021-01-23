    protected void Page_Load(object sender, EventArgs e)
    {
        btnTest.Attributes.Add("problem", problems[p]);
    }
    
    protected void btnTest_Click(object sender, EventArgs e)
    {
        string problem = (sender as LinkButton).Attributes["problem"];
        //or even
        problem = btnTest.Attributes["problem"]
    }
