    int pingCount = 0;
    private void pingClient_PingCompleted(object sender, PingCompletedEventArgs e)
    {
         pingCount++;
         //if error else logic etc
         if(pingCount < 3) {
            pingClient.SendAsync(addressTextBox.Text, null);
         } else {
            sendButton.Enabled = true;
         }
    }
    private void sendButton_Click(object sender, EventArgs e)
    {
        pingCount = 0;
        //etc
    }
