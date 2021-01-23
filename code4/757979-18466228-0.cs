    protected void Page_Load(object sender, EventArgs e)
    {
    if (!Page.IsPostBack)
    {
    Session["IsPageRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
    }
    }
    
    protected void Page_PreRender(object sender, EventArgs e)
    {
    ViewState["IsPageRefresh"] = Session["IsPageRefresh"];
    }
    protected void btnPost_Click(object sender, EventArgs e)
    {
    if (Session["IsPageRefresh"].ToString() == ViewState["IsPageRefresh"].ToString())
    {
    //Put your database INSERT code here
    Session["IsPageRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
    }
    }
 
