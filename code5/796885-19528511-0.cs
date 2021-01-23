    //EditingControlShowing event handler for your dataGridView1
    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e){
      ComboBox combo = e.Control as ComboBox;
      if(dataGridView1.CurrentCell.OwningColumn == column_you_want){
         combo.SelectedIndexChanged -= combo_SelectedIndexChanged;
         combo.SelectedIndexChanged += combo_SelectedIndexChanged;
      }
    }
    private void combo_SelectedIndexChanged(object sender, EventArgs e){
       //....
    }
