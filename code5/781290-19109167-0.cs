    //CellBeginEdit event handler for your myDataGridView
    private void myDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e){
        (myDataGridView.DataSource as DataTable).DefaultView.RowFilter = "";
    }
    //you can call this method such as in some Click event handler of some Refresh Button
    public void RefreshGrid(){
      (myDataGridView.DataSource as DataTable).DefaultView.RowFilter = "[myColumn] = 'value'";
    }
