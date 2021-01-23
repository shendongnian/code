    private void lst_CallData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView selectedRowView = this.lst_CallData.SelectedItem as DataRowView;
            if(selectedRowView != null)
            {
                DataRow selectedRow = selectedRowView.Row; // To get the partcular data row
                DataTable inputTable = selectedRowView.DataView.Table; //To get the entire table data
            }
        }
