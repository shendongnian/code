    private void txtSearch_TextChanged(object sender, EventArgs e)
    {
        var con = new SqlConnection("{your connection string}");
        con.Open();
        String query = "select LastName from JoshTestTable where LastName like '%" + txtSearch.Text.Trim() + "%'";
        var cmd = new SqlCommand(query, con);
        var rr = cmd.ExecuteReader();
        var namesCollection = new AutoCompleteStringCollection();
        while (rr.Read())
            namesCollection.Add(rr["LastName"].ToString());
        rr.Close();
        con.Close();
        txtSearch.AutoCompleteCustomSource = namesCollection;
        txtSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
        txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
    }
