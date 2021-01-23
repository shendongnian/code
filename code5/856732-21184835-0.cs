    public void appendMessage(string message)
    {
        ListBoxItem item = messageBox.Items[messageBox.Items.Count-1];
        item.Content = ((string)item.Content) + message;
    } 
