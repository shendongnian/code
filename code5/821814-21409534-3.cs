    private void LastColumnComboSelectionChanged(object sender, EventArgs e)
    {
    	var sendingCB = sender as DataGridViewComboBoxEditingControl;
    	var currentcell = mappingDataGridView.CurrentCellAddress;
    
    	if (currentcell.X == 0)
    	{
    		object value = sendingCB.SelectedItem;
    		if (value != null)
    		{
    			string itemValue = (string)sendingCB.SelectedItem;
    			//
    			// or with an other object it looks like this:
    			// int intValue = ((ComboBoxItem)sendingCB.SelectedItem).hiddenValue;
    		}
    	}
    }
