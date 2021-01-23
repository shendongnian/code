    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
      var tb =(DataGridViewTextBoxEditingControl)e.Control;
      tb.KeyPress += new KeyPressEventHandler(dataGridViewTextBox_KeyPress);
    
      e.Control.KeyPress += new KeyPressEventHandler(dataGridViewTextBox_KeyPress);
    }
    
    private void dataGridViewTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
    }
