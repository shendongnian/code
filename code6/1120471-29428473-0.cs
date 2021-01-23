    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var query = "select * from users";
            try
            {
                using (var adp = new SqlDataAdapter(query, @"data source=.\SQLEXPRESS;...;"))
                using (var dt = new DataTable())
                {
                    adp.Fill(dt);
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
