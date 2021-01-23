    private void filter_table()
    {
        .... your code
        dataGridView1.DataSource = dt;
        cbHeader = (DatagridViewCheckBoxHeaderCell)dataGridView1.Columns[0].HeaderCell;
        cbHeader.OnCheckBoxClicked += new CheckBoxClickedHandler(cbHeader_OnCheckBoxClicked);
    }
