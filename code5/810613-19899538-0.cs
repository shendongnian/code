    private void tabControl1_ControlAdded(object sender, ControlEventArgs e)
    {
        if (e.Control.GetType() == typeof(TabPage)) {
            MessageBox.Show("Yippee!"); // Insert code here
        }
    }
    
