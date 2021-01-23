    foreach(UIElement element in parent.Children)
    {
        if(element is ComboBox)
        {
            ComboBox cb = (ComboBox)element;
            ComboBoxItem Item = cb.SelectedItem; 
            allnos.AddLast(Item.Content);
        }
    }
