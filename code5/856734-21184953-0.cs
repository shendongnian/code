    ListBoxItem LastItem;
    
    public void showMessage(string message, bool InLine)
    {
        if (InLine)
            LastItem.Content += message;
        else
            messageBox.Items.Add(LastItem = new ListBoxItem() { Content = message });
    }
