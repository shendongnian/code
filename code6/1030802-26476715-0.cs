    protected void GridView_PreRender(object sender, EventArgs e)
    {
        foreach (DataControlField column in GridView1.Columns)
            if (column.HeaderText == "XXXXXXX")
                column.Visible = false;
    }
