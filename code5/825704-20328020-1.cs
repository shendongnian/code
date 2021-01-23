    var txt = comboBox1.Text;
    
    if (!listView1.Items.ContainsKey(txt))
    {
        lvi.Text = txt;
    
        // this is the key that ContainsKey uses. you might want to use the value 
        // of the ComboBox or something else, depending the combobox is freetext 
        // or regarding your scenario.
        lvi.Name = txt;
    
        lvi.SubItems.Add("");
        lvi.SubItems.Add("");
        lvi.SubItems.Add("");
        lvi.SubItems.Add("");
    
        listView1.Items.Add(lvi);
    }
