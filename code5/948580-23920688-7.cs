    private void messageText_TextChanged(object sender, TextChangedEventArgs e)
    {
        // if timer already running, then don't update status
        if (!timer.Enabled)
            chatApp.WriteChatLine(userName + "is typping...");
        
        timer.Stop(); // restart timer
        timer.Start();
    }
    private void timer_Tick(object sender, EventArgs e)
    {
        ClearStatus();        
    }
    
    private void buttonSend_Click(object sender, EventArgs e)
    {
        // send message
        ClearStatus();
    }
    
    private void ClearStatus()
    {
         chatApp.WriteChatLine(""); // some code which clears status message
         timer.Stop(); // stop timer
    }
