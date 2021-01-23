    if(comboBox.SelectedItem != null)
    {
        string some_str = comboBox.SelectedItem.ToString(); // <-- Exception
        if (some_str.Contains("abcd"))
        {
            // ...
        }
    }
    else
    {
         MessageBox.Show("Please select an item");
    }
