    //use some variable to store the last edited value
    string editingValue;
    //EditingControlShowing event handler
    private void dataGridView1_EidtingControlShowing(object sender, 
                                      DataGridViewEditingControlShowingEventArgs e) {
      var combo = e.Control as ComboBox;
      if(combo != null){
         combo.DropDownStyle = ComboBoxStyle.DropDown;
         combo.TextChanged += (s,ev) => {
           editingValue = combo.Text;
         };
      }
    }
    //CellEndEdit event handler for your dataGridView1
    private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e){
      var comboColumn = dataGridView1.Columns[e.ColumnIndex] as DataGridViewComboBoxColumn;
      if(comboColumn != null && editingValue != "" && 
         !comboColumn.Items.Contains(editingValue)){
         comboColumn.Items.Add(editingValue);
         dataGridView1[e.ColumnIndex, e.RowIndex].Value = editingValue;
      }
    }
