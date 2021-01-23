    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var query = "select * from users";
            try
            {
                // DataAdapters and DataTables are IDisposable
                using (var adp = new SqlDataAdapter(query, @"data source=.\SQLEXPRESS;...;"))
                using (var dt = new DataTable())
                {
                    adp.Fill(dt);
                    // Bind the datatable to the grid
                    gridUsers.DataSource = dt;
                    gridUsers.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
