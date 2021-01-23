    DataGridViewColumn getcol;
    foreach(DataGridViewColumn c in DataGridView1.Columns)
    {
        if(c.Tag as String == "10")
        {
            getcol = c;
        }
    }
