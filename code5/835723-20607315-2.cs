    public string ReqID0;
    string Status0 { get; set; }
    string Status = "";
    string ConnectionString =    ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    SqlConnection sqlc4;
  
    protected void Page_Load(object sender, EventArgs e)
    {
    if (!this.IsPostBack)
    {
        ReqIDLbl.Text = ReqID0;
        ViewState["ReqID0"].ToString();//ViewState
      ------
     }
