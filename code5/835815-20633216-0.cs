    //The EditingControlShowing event handler for your dataGridView1
    private void dataGridView1_EditingControlShowing(object sender, 
                                              DataGridViewEditingControlShowingEventArgs e){
       var control = e.Control as TextBox;
       if(control != null && 
          dataGridView1.CurrentCell.OwningColumn.Name == "Interested Column Name"){
          control.TextChanged -= textChanged_Handler;
          control.TextChanged += textChanged_Handler;
       }
    }
    private void textChanged_Handler(object sender, EventArsg e){
      var control = sender as Control;
      if(control.Text == "interested value") {
         //disable your button here
         someButton.Enabled = false;
         //do other stuff...
      } else {
         someButton.Enabled = true;
         //do other stuff...
      }
    }
