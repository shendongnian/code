    private void SetCompanyList()
    {
        if (string.IsNullOrEmpty(Convert.ToString(mainCatU.SelectedValue)) || string.IsNullOrEmpty(Convert.ToString(subCatU.SelectedValue))) return;
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = "Data Source=\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";
        conn.Open();
        SqlDataAdapter daMain = new SqlDataAdapter("SELECT cName FROM ComDet where mainCate = @mainCat subCat = @subCate", conn);
        daMain.SelectCommand.Parameters.Add("@mainCat", SqlDbType.VarChar).Value = mainCatU.SelectedValue;
        daMain.SelectCommand.Parameters.Add("@subCate", SqlDbType.VarChar).Value = subCatU.SelectedValue;
        DataTable _table = new DataTable();
        daMain.Fill(_table);
        ListU.DataSource = _table;
    }
