    private void Button_Click(object sender, RoutedEventArgs e)
    {
        string tempCopy = SelectedText; // Create a copy of the current value
        var changed = Items.ToList();
        int index = changed.IndexOf(SelectedText);
        if (index >= 0)
        {
            changed[index] += "a";
        }
        Items = changed;
        SelectedText = tempCopy; // Replace the selected text with the copy we made
    }
