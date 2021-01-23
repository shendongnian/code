    DataTable dt = new DataTable();
    public int namesCounter;
    protected void Page_Load(object sender, EventArgs e)
    {
        dt.Columns.Add("ID", typeof(Int32));
        dt.Columns.Add("name", typeof(string));
        
           //namesCounter = 0;
            if (!IsPostBack)
            {
                ViewState["Number"] = 0;
                ViewState["table"] = dt;
            }
        names_GV.DataSource = dt;
        names_GV.DataBind();
    }
    protected void addName_Click(object sender, EventArgs e)
    {
        dt = (DataTable)ViewState["table"];
        namesCounter = Convert.ToInt32(ViewState["Number"]) + 1;
        ViewState["Number"] = namesCounter;
        DataRow dtrow = dt.NewRow();
        dtrow[0] = namesCounter;
        // dtrow["ID"] = namesCounter;
        dtrow["name"] = newName_TXT.Text;
        dt.Rows.Add(dtrow);
        ViewState["table"] = dt;
        names_GV.DataSource = dt;
        names_GV.DataBind();
    }
