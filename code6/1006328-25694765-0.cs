    RadGridView radGridView1;
    DataTable table = new DataTable();
    table.Columns.Add("Protocol", typeof(string));
    table.Columns.Add("Property Value1", typeof(string));
    table.Columns.Add("File", typeof(string));
    radGridView1.ShowColumnHeaders = false;
    radGridView1.ShowGroupPanel = false;
    radGridView1.ShowRowHeaderColumn = false;
    radGridView1.AllowAddNewRow = false;
    radGridView1.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
    radGridView1.GroupDescriptors.Add(new Telerik.WinControls.Data.GroupDescriptor("File"));
    radGridView1.DataSource = table;
    private void AddFile(string file)
    {
        table.Rows.Add("File size:", "", file);
        table.Rows.Add("File duration:", "",  file);
        table.Rows.Add("Creation time:", "", file);
    }
