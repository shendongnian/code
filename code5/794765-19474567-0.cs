    private void radioButtonViewAll_CheckedChanged(object sender, EventArgs e)
    {
        TxtLibrary myList = new TxtLibrary(filePathBooks);
        myList.chooise = "all";
        DataTable table = new DataTable();
        //add columns first
        table.Columns.Add("ID");
        table.Columns.Add("Author");
        table.Columns.Add("Caption");
        table.Columns.Add("Categories");
        //then add rows
        foreach (var array in myList.ReadFromFileBooks()) {
            table.Rows.Add(array);
        }
        dataGridViewLibrary.DataSource = table;
    }
