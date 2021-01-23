    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("Column1", typeof(string));
            dt.Columns.Add("Column2", typeof(string));
            ds.Tables.Add(dt);
            for (int i=0; i<5; i++)
            {
                DataRow nw = ds.Tables[0].NewRow();
                nw[0] = (i + 1).ToString();
                nw["Column1"] = (i + 1).ToString();
                nw["Column2"] = String.Format("Item {0}", i);
                ds.Tables[0].Rows.Add(nw);
            }
            bindGridView(ds.Tables[0], g1, lblErrorActivityGrid, lblActivityGridCount);
        }
    }
            
    
    private void bindGridView(DataTable dt, GridView grd, Label lblError, Label GrdRowCount)
    {
        grd.DataSource = dt;
        grd.DataBind();
    }
