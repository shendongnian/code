    public int CurrentYear
    {
        get {
            if(ViewState["currentYear"] != null)
                return (int)ViewState["currentYear"];
            return 2014; //Default
        }
        set {
            _ViewState["currentYear"]= value;
        }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            dgvRequests.DataSource = GetYearData(CurrentYear); //Or Your variable
            dgvRequests.DataBind();
            }
    }
