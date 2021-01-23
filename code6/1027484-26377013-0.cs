    private Dictionary<string, List<string>> _items;
    
    private void cmbUsers_SelectedIndexChanged(object sender, EventArgs e)
    {
        var cmbText = cmbUsers.SelectedText;
        cmbList.Items.Clear();
        if (_items.ContainsKey(cmbText)
        {
            cmbList.Items.AddRange(_items[cmbList]);           
        }
        else // default : show all items
        {
            foreach (var val in _items.Values)
            {
                cmbList.Items.AddRange(val);
            } 
        }        
    }
