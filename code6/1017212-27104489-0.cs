    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            PopulateDDL();
        }
    }
    protected void PopulateDDL()
        {
            DropDownList ddl_Location = (DropDownList)fmv_DataTown.FindControl("ddl_Location");
            DropDownList ddl_FilteredLocation = (DropDownList)fmv_DataTown.FindControl("ddl_FilteredLocation");
            ddl_Location.Items.Clear();
            DataView view = (DataView)ds_Location.Select(DataSourceSelectArguments.Empty);
            DataTable dt = view.ToTable();
            
            foreach (DataRow row in dt.Rows)
            {
                
                string Town = row["Town"].ToString();
                string FullText = "";
                if (Town.Length > 0)
                {
                    FullText = Town;
                }
                else
                {
                    
                }
                ddl_Location.Items.Add(new ListItem(FullText, FullText));
            }
        }
