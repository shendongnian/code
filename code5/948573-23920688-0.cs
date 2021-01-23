    private void messageText_TextChanged(object sender, TextChangedEventArgs e)
    {
        chatApp.WriteChatLine(userName + "is typping...");
        messageText.TextChanged -= messageText_TextChanged;
    }
