     protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    
                loadGrid();
                }
            }
            public void loadGrid()
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Menu", typeof(string));
                dt.Columns.Add("ParentID", typeof(string));
                dt.Columns.Add("MenuID", typeof(string));
    
    
                dt.Rows.Add("Name", "1", "1");
                dt.Rows.Add("Name1", "1", "2");
                dt.Rows.Add("Name2", "1", "3");
                dt.Rows.Add("Name3", "1", "4");
                dt.Rows.Add("Name4", "1", "5");
                dt.Rows.Add("Class", "2", "6");
                dt.Rows.Add("Class1", "2", "7");
                dt.Rows.Add("Class2", "2", "8");
                dt.Rows.Add("Class3", "2", "9");
                dt.Rows.Add("Class4", "2", "10");
                dgvHMDEditorialManage.DataSource = dt;
                dgvHMDEditorialManage.DataBind();
    
            }
