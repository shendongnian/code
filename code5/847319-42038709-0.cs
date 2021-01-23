    bool handled;
    private void lstItems_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
    	if (!handled)
    	{	handled = true;
    		Application.Idle += SelectionChangeDone;   }
    }
    
    private void SelectionChangeDone(object sender, EventArgs e) {
    	Application.Idle -= SelectionChangeDone;
    	handled = false;
    	
    	if (lstItems.SelectedItems.Count > 0)
			 cmbMoveUp.Enabled = cmbMoveDn.Enabled = true;
		else cmbMoveUp.Enabled = cmbMoveDn.Enabled = false;
    }
