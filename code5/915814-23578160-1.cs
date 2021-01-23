    **[cs]**
  
      protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                GetData();
            this.GridGroupingControl1.RowDataBound += GridGroupingControl1_RowDataBound;
        }
        protected void GridGroupingControl1_RowDataBound(object sender,RowDataBoundEventArgs e)
        {
            if (e.Element.Kind == DisplayElementKind.Record)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (((GridCell)e.Row.Cells[i]).ColumnDescriptor.Name == "City")
                    {
                        myConnection = new SqlConnection(ConnectionString);
                        myConnection.Open();
                        DropDownList ddl = (DropDownList)e.Row.Cells[i].FindControl("ddlCity");
                        SqlCommand cmd = new SqlCommand("SELECT Distinct City FROM Employees", 
                                                 myConnection);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        myConnection.Close();
                        ddl.DataSource = ds;
                        ddl.DataTextField = "City";
                        ddl.DataValueField = "City";
                        ddl.DataBind();
                        ddl.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                }
            }
        }
