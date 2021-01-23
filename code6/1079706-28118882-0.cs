    DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn();
    col.Name = "myColumn";
    // Set any other desired properties ...
    
    if (!dataGridView1.Columns.Contains(col.Name))
    {
        dataGridView1.Columns.Add(col);
    }
