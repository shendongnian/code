    string baseFilter = "[myColumn] = 'value'";
    //CellEndEdit event handler for your myDataGridView
    private void myDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e){
        (myDataGridView.DataSource as DataTable).DefaultView.RowFilter = baseFilter + " OR [myColumn] = '" + myDataGridView[e.ColumnIndex,e.RowIndex].Value + "'";
    }
    //you can call this method such as in some Click event handler of some Refresh Button
    public void RefreshGrid(){
      (myDataGridView.DataSource as DataTable).DefaultView.RowFilter = baseFilter;
    }
