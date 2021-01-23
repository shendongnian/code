    // Want to edit the value of the Item
    Edit editbutton = new Edit();
    var item = basket.Items[lst_Results.SelectedIndex];
    
    editbutton.NameOfItem = item.ItemName;
    editbutton.Quantity = item.Quantity;
    editbutton.ReplacementValue = item.Price;
    if (editbutton.ShowDialog() == DialogResult.OK)
    {
        basket.UpdateReplacementValue(item.ItemName, editbutton.Quantity, editbutton.ReplacementValue);
        RenderLibrary();
    }
