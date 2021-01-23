        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadCountries();
                LoadWines();
            }
        }
        private void LoadCountries()
        {
            SqlConnection conn = new SqlConnection("...");
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT Country FROM Wines", conn);
            conn.Open();
            var reader = cmd.ExecuteReader();
            ddlCountries.DataSource = reader;
            ddlCountries.DataBind();
            reader.Close();
            conn.Close();
        }
        private void LoadWines()
        {
            var query = "SELECT * FROM Wines";
            if (ddlCountries.SelectedValue != "all")
            {
                query = query + " WHERE Country =  '" + ddlCountries.SelectedValue + "'";
            }
            if (ddlSorting.SelectedValue != "default")
            {
                query = query + " ORDER BY " + ddlSorting.SelectedValue;
            }
            
            SqlConnection conn = new SqlConnection("...");
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            var reader = cmd.ExecuteReader();
            lstResult.DataSource = reader;
            lstResult.DataBind();
            reader.Close();
            conn.Close();
        }
        protected void ddlSorting_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadWines();
        }
        protected void ddlCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadWines();
        }
