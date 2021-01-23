    private List<string> _selectedItems = new List<String>();
    public List<string> SelectedItem
    {
    	get {return _selectedItems;}
    }
    
    private void btnSelect_Click(object sender, EventArgs e)
    {
    	for(int i=0; i<lst.Items.Count;i++)
    	{
    		if (lstContenType.GetItemCheckState(i) == CheckState.Checked)
    			_selectedItems.Add(lst.Items[i].ToString());
    	}
    	this.Close();
    }
