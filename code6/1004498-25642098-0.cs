    private bool close= true; 
    
    private void CheckBox1_CheckedChanged(Object sender, EventArgs e)
    {
     close= false; 
    }
    
    private void contextMenu_Closing(object sender, ToolStripDropDownClosingEventArgs e)
    {
      e.Cancel = !close;
      CloseContextMenu = true;
    }
