    protected void Page_Load(object sender, EventArgs e)
    {
        //Get the query string called tab
        private string tab = Request.Querystring("tab");
        //Check that query string is not null
        if(tab!=null)
        {
           //Run JavaScript. NB: the parameter passed to this is based off our query string
           ScriptManager.RegisterStartupScript(this, typeof(string), "Registering", String.Format("openTab('{0}');", tab), true);
        }
        
    }
