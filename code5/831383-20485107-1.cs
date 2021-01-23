    private bool _programChangingSelection;
    
    private void SelectionChanged(object sender, EventArgs e)
    {
        if (_programChangingSelection)
        {
           _programChangingSelection = false;
           return;
        }
    
        if (e.IsSelected)
        {
            DialogResult GetDialogResult = 
                   MessageBox.Show("Keep this item selected?", 
                   "Keep Selected", 
                   MessageBoxButtons.YesNo);
    
            if (GetDialogResult == DialogResult.No)
            {
                _programChangingSelection = true;
                listView1.SelectedItems[0].Selected = false;
            }
        }
    }
