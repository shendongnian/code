    private void messageText_TextChanged(object sender, TextChangedEventArgs e)
    {
        IsUserTyping = true;
    }
    private void timer_Tick(object sender, EventArgs e)
    {
        IsUserTyping = false;
    }
    
    private void buttonSend_Click(object sender, EventArgs e)
    {
        // send message
        IsUserTyping = false;
    }
    private bool IsUserTyping 
    {
        get { return timer.Enabled; }
        set {
            if (value)
            {
                if (!IsUserTyping)
                    chatApp.WriteChatLine(userName + "is typping...");
                timer.Stop();
                timer.Start();
            }
            else
            {
                timer.Stop();
                chatApp.WriteChatLine("");
            }
        }        
    }
