    // sample data
    gridControl1.DataSource = new List<DataObj> { 
        new DataObj(){ Agent = "AMD" },
        new DataObj(){ Agent = "!!!AMD" },
    };
    //...
    gridView1.PopulateColumns();
    foreach(GridColumn column in gridView1.Columns) // disable editing for all columns
        column.OptionsColumn.AllowEdit = false;
    gridView1.Columns["Description"].OptionsColumn.AllowEdit = true; // enable editing for specific column
    //...
    class DataObj {
        public string Agent { get; set; }
        public string Description { get; set; }
    }
