    var cb1 = new ComboBox();
    var cb2 = new ComboBox();
    cb1.Items.AddRange(firstItems); // whatever you want to put into the first ComboBox
    cb2.Items.AddRange(secondItems); // whatever you want to put into the second ComboBox
    public void ChangeSelectionInSecondComboBox(object sender, EventArgs e)
    {
        var selectedItem = cb1.SelectedItem;
        if(selectedItem == [...]) // depends on how you want to decide which item 
                                     to display in ComboBox2
        {
            cb2.SelectedIndex = [...] // you need to decide which Index to set
        }
    }
    cb1.SelectedIndexChanged += ChangeSelectionInSecondComboBox;
