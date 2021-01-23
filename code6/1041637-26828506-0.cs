    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            Response.Write(Request.Form["jsonString"]); //stuck here
        }      
    }
