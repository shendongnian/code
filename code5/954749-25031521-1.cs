    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Method"] == "CountOfMenus")
            {
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                GetCount(Request.QueryString["SD"], Request.QueryString["ED"]);
            }
        }
 
        private void GetCount(string StartDate, string EndDate)
        {
            Response.Clear();
            
            // Code to get count
            Response.Write(Count.ToString());
            Response.End();
        }
