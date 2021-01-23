    protected void Page_Load(object sender, EventArgs e)
    {
    if (!Page.IsPostBack)
    {
    	if (Request.QueryString["back"] != null)
    		bindDataFirst();
    // same data load logic as present
    	else
            	bindDataForBack();
    // you come back from detail page hence bind search & grid data
    }
    private void bindDataForBack()
        {
    
    strName = Session["SearchName"] == null ? "" : Session["SearchName"].ToString();
    // check session search conditions & data and bind
    
    //also bind grid by respective search parameters & search options (top side)
