    class itemClass
    {
        public string display { get; set;}
        public string value { get; set; }
        public itemClass(string d, string v) 
        { display = d; value = v;}
    }
    List<itemClass> myItems = new List<itemClass>();
    private void loadButton_Click(object sender, EventArgs e)
    {
        // load the list with all values:
        myItems.Add(new itemClass("zero", "0"));
        myItems.Add(new itemClass("one", "1"));
        myItems.Add(new itemClass("two", "2"));
        myItems.Add(new itemClass("three", "3"));
        myItems.Add(new itemClass("four", "4"));
        myItems.Add(new itemClass("five", "5"));
        myItems.Add(new itemClass("six", "6"));
        // prepare the DataGridView 'DGV':
        DGV.Columns.Clear();
        DataGridViewComboBoxCell cCell = new DataGridViewComboBoxCell();
        DataGridViewComboBoxColumn cCol = new DataGridViewComboBoxColumn();
        DGV.Columns.Add(cCol);
        cCol.DisplayMember = "display";
        cCol.ValueMember = "value";
        cCol.DataSource = myItems;
        cCol.ValueType = typeof(string);
        // add a few rows, for testing:
        DGV.Rows.Add(7);
        for (int i = 0; i < DGV.Rows.Count; 
            i++) DGV.Rows[i].Cells[0].Value = i + "";
    }
