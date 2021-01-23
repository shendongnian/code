    private void RunChat()
    {
        StreamReader reader = new StreamReader(client.GetStream());
            
        while (true)
            AppendChatText(reader.ReadLine());
    }
    private void AppendChatText(string text)
    {
        if (this.InvokeRequired)
        {
            this.Invoke((Action<string>)AppendChatText, text);
            return;
        }
        chatDisplay.AppendText(text + "\r\n");
        chatDisplay.SelectionStart = chatDisplay.Text.Length;
    }
