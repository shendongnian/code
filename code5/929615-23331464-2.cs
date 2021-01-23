    protected void Page_Load(object sender, EventArgs e)
    {
         if (!Page.IsPostBack)
         {
             ViewState["Book_CategoryName"] = "Education";
         }
    }
    
    public void BookDataLinkButton_Click(object sender, EventArgs e)
    {
         Response.Write("Data Found :: " + (string)ViewState["Book_CategoryName"]);
    }
