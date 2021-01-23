     private void TaskGridView_CellValueChanged(object sender, CellValueChangedEventArgs e)
     {
            if (e.RowHandle < 0)
                    return;
    
            var row = TaskGridView.GetRow(e.RowHandle) as YourModel;
    
           if (e.Column.FieldName.Equals("YourFieldName", StringComparison.InvariantCultureIgnoreCase))
           {
               // do something here
           }       
      }
