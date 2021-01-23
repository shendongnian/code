    protected void Page_Load(object sender, EventArgs e)
    {
       // set OnClientClick 
       btnConfirm.OnClientClick = "return Validate();";
    }
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        //save something in database
    }
