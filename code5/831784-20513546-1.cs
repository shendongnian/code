    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.Columns[7].Visible = false;
    }
    
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string code = GridView1.DataKeys[GridView1.SelectedIndex].Value.ToString();
        SqlDataSource1.SelectCommand = "SELECT * FROM [BookingRoom] WHERE code = '" + code + "'";
            
        GridView1.Columns[8].Visible = true;
        GridView1.SetEditRow(0);
    }
    
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.Columns[7].Visible = true;
        GridView1.Columns[8].Visible = false;
    }
