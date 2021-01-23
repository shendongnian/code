    protected void Page_Load(object sender, EventArgs e)
    {
        String CS = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(CS);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "EmployeeDetails";
        cmd.Connection = con;
        DataTable dt = new DataTable();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (dt.Rows[i]["Size"].ToString() == "N/A")
                continue;
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                object colVal = dt.Rows[i][j];
                if (colVal == DBNull.Value || Convert.ToDecimal(colVal) == 0)
                {
                    decimal calVal = (Convert.ToDecimal(dt.Rows[i + 1][j]) / Convert.ToDecimal(dt.Rows[i + 1]["R"])) * Convert.ToDecimal(dt.Rows[i]["R"]);
                    dt.Rows[i][j] = calVal;
                }
            }
        }
    GridView1.DataSource = cmd.ExecuteReader();
    GridView1.DataBind();
    }
