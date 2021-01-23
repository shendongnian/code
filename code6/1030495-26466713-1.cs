    protected void radDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        string query = BuildQuery(radDropDownList.SelectedValue);  //Pass in the table name
        using (var cn = new SqlConnection(connString))
        {
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(query, cn);
                using (var da = new SqlDataAdapter(cmd))
                {
                    ad.Fill(dt);
                }
            }
            catch (SqlException e)
            {
               //TODO: Handle this exception.
            }
        }
        radGrid.DataSource = dt;
        radGrid.DataBind();
    }
    private string BuildQuery(string table)
    {
        //TODO:  Provide your own implementation for your query.
        return string.Format(
            @"SELECT * FROM {0}", table);
    }
