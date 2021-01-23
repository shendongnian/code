    //To Send
    private void submit_Click(object sender, System.EventArgs e)
    {
        string ID = String.Empty;
        ID = "192" // Have your ID Here
        Response.Redirect("humanEdit.aspx?ID=" + ID );
    }
    //To Receive
    private void Page_Load(object sender, System.EventArgs e)
    {
       String ID = String.Empty;
       ID=Request.QueryString["name"];
    }
