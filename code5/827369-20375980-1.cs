    //EditingControlShowing event handler for your dataGridView1
    private void dataGridView1_EditingControlShowing(object sender,
                                       DataGridViewEditingControlShowingEventArgs e){
       if(dataGridView1.CurrentCell.OwningColumn == cmbItems){
         var combo = e.Control as ComboBox;
         combo.SelectedIndexChanged -= cmbItems_SelectedIndexChanged;
         combo.SelectedIndexChanged += cmbItems_SelectedIndexChanged;
       }   
    }
    private void cmbItems_SelectedIndexChanged(object sender, EventArgs e){
       var combo = sender as ComboBox;
       //Note that SelectedItem may be null
       var s = Convert.ToString(combo.SelectedItem);
       int i = s.IndexOf(" :Qty");
       var selectedName = i == -1 ? "" : s.Substring(0,i+1).TrimEnd();
       //other code ...
    }
    
