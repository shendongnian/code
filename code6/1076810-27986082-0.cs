    // subscribe to the event that goes with entering edit mode:
    private void dataGridView1_EditingControlShowing(object sender, 
                               DataGridViewEditingControlShowingEventArgs e)
    {
        DataGridViewTextBoxEditingControl tb = DataGridViewTextBoxEditingControl)e.Control;
        tb.KeyPress += new KeyPressEventHandler(dataGridViewTextBox_KeyPress);
        tb.MouseDown += tb_MouseDown;
        tb.MouseUp += tb_MouseUp;
        e.Control.KeyPress += new KeyPressEventHandler( dataGridViewTextBox_KeyPress);
    }
    private void dataGridViewTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        if ( dataGridView1.Columns[ dataGridView1.CurrentCell.ColumnIndex].Frozen)
        {
            // actually we don't allow Ctrl-C etc but for safety..
            // d..elete the clipboard content
            Clipboard.Clear();
            e.Handled = true;
        }
    }
    void tb_MouseUp(object sender, MouseEventArgs e)
    {
        if (dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].Frozen)
        {
            // delete the clipboard content
            Clipboard.Clear();
        }
    }
    void tb_MouseDown(object sender, MouseEventArgs e)
    {
        
        if (dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].Frozen)
        {
          // ?? I wish I knew how to suppress the standard popup menu ??      
        }
    }
