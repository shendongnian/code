    private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        bindingSource1.EndEdit();
        DataTable dt = (DataTable)bindingSource1.DataSource;
        // Just for test.... Try this with or without the EndEdit....
        DataTable changedTable = dt.GetChanges();
        Console.WriteLine(changedTable.Rows.Count);
        int rowsUpdated = da.Update(dt);    
        Console.WriteLine(rowsUpdated);
    }
