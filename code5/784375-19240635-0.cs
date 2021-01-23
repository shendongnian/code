    protected void GridView1_PageIndexChanging(Object sender, GridViewPageEventArgs e)
    {
        int index = e.NewPageIndex + 1;
        string url = HttpContext.Current.Request.Url.AbsoluteUri;
        e.Cancel;
    
        Response.Redirect(string.Format("{0}?page={1}", url, index));
    }
    
    PageLoad(...)
    {
        if (!Page.IsPostBack)
        {
              if (Request.QueryString["page"] != null)
              {
                  int index = int.Parse(Request.QueryString["page"]);
                  // bind your gridview
                 GridView1.PageIndex = index;
              }
        }
    }
