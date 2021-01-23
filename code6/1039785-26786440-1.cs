    private void BeginUpdate()
    {
    	//if the DataSource is going to be empty, adding the first item will
    	//always trigger an ArgumentOutOfRangeException on the selected index.
    	//to avoid this, we must stop the binding during the modification of the list.
    	_Updating = true;
    	comboBox1.DataSource = null;
    }
    
    private void EndUpdate()
    {
    	if (bindingList.Count > 0)
    	{
    		//the binding will set SelectedIndex to the old index when rebinding and it's possibily the wrong one.
    		//the good index is always 0 but we set the index to -1 before to be sure to be able to trigger the
    		//selectedIndex_changed method after _UpdatingRecentFolders is turn to false
    		comboBox1.DataSource = bindingList;
    		comboBox1.SelectedIndex = -1;
    		_Updating = false;
            //I always want 0 but you can place the index you want
    		comboBox1.SelectedIndex = 0;
    	}
    	else
    	{
    		comboBox1.DataSource = null;
    		_Updating = false;
    		comboBox1.SelectedIndex = -1;
    	}
    }
