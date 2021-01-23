    public void ScanRows()
    {
        foreach (DataGridViewRow row in GridView1.Rows)
        {
           row.DefaultCellStyle.BackColor = Color.Green;
           //Indicate that this row already was scanned
           row.Tag = true;
        }
    }
    protected void GridView_OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        var row = GridView1.SelectedRow;
        if (!((bool)(row.Tag ?? false)))
        {
           errorLabel.Text = "ERROR - cannot edit this row";
        }
        else
        {
            //Different code
        }
    }
