        private void gridView1_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e) {
        
            GridView view = sender as GridView; 
        
            if(view.FocusedColumn.FieldName == "Name" || view.FocusedColumn.FieldName == "Class" 
    ||  !newRow(view, view.FocusedRowHandle))
                    e.Cancel = true;
        
        }
