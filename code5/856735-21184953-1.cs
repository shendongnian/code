    public void showMessage(string message, bool InLine)
    {
        if (InLine)
            messageBox.Items[messageBox.Items.Count-1] += message;
        else
            messageBox.Items.Add(message);
    }
