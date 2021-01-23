    DataSet ds2;
    private void searchBtn_Click(object sender, EventArgs e)
    {
    SqlConnection conn = new SqlConnection();
    conn.ConnectionString = "Data Source=.\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";
    conn.Open();
    SqlDataAdapter daSearch = new SqlDataAdapter("SELECT cName FROM ComDet", conn);
    ds2 = new DataSet();
    daSearch.Fill(ds2, "daSearch");
    ListU.ValueMember = "cName";
    ListU.DataSource = ds2.Tables["daSearch"];
    ListU.DropDownStyle = ComboBoxStyle.DropDownList;
    ListU.Enabled = true;
    }
