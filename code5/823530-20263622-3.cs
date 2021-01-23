    foreach (var listItem in listBox.Items.Cast<ListItem>().Where(x => x.Selected))
    {
        string displayText = listItem.Text;
        string value = listItem.Value;
    
        // Do something with that...
    }
