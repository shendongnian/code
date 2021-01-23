    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDropdowns();
        }
    }
    private void BindDropdowns()
    {
        String queryString = "SELECT TAG from dbo.Tags";
        List<String> tagsShow = new List<String>();
        tagsShow.Add("Show all");
        using (SqlConnection conn = new SqlConnection(info.connectionString))
        using (var cmd = conn.CreateCommand())
        {
            conn.Open();
            cmd.CommandText = queryString;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    tagsShow.Add(reader.GetString(0));
                }
            }
        }
    
        showDBDropDown.DataSource = tagsShow;
        showDBDropDown.DataBind();
    }
