    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request.QueryString["id"].ToString();
        var myResult = getProjectByID(Convert.ToInt32(id));
        if(myResult != null)
        {
            myDiv.InnerHtml = myResult.ProjectContactFirstName;  
        }
    }
