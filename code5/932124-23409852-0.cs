    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if(!String.IsNullOrEmpty(Request.QueryString["id"]))
            {
                string id=Request.QueryString["id"];
                //load data based on the id
            }
            else
            {
                 //tell the user they can't navigate directly to this page.
            }
        }
    }
