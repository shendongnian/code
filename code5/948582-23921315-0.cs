    bool textboxChanged = false;
    private void messageText_TextChanged(object sender, TextChangedEventArgs e)
    {
        if(!textboxChanged) //if not changed
        {
            chatApp.WriteChatLine(userName + "is typping...");
        }
    }
