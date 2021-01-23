    if (lstItemCode.SelectedItem == null)
        return;
    if (lstItemCode.SelectedItem.ToString().Contains("Complete"))
    {
        int idx = lstItemCode.Items.IndexOf(lstItemCode.SelectedItem);
    
        if(idx != -1)
            lstItemCode.Items[idx] = lstItemCode.SelectedItem.ToString().Replace("Complete", string.Empty).Trim();
    }
