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
        ReqID0 = ViewState["ReqID0"].ToString();//ViewState
      /*In case if the above code doesn't work use 
       ReqIDLbl.Text =  ViewState["ReqID0"].ToString();*/
      ------
     }
