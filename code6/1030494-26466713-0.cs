    protected void radDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        string query = BuildQuery(radDropDownList.SelectedValue);  //Pass in the table name
        DataTable table = new DataTable();
        //TODO:  Setup SqlCommand and SqlTableAdapter
        dataAdapter.Fill(table);
        radGrid.DataSource = table;
        radGrid.DataBind();
    }
