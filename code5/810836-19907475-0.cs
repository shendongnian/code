    gridControl1.DataSource = new List<Person> { 
        new Person(){ Name="John Smith"},
        new Person(){ Name="Mary Smith"}
    };
    gridView1.OptionsBehavior.Editable = false; // disable editing
    gridView1.RowCellClick += gridView1_RowCellClick;
    //...
    void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e) {
        if(e.Clicks == 2) { // Double Click
            object cellValue = e.CellValue;
            //do some stuff
        }
    }
    //...
    class Person {
        public string Name { get; set; }
    }
