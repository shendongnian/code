    private bool HasBeginAndEnd(string[] message)
    {
        bool isValid = true;
    
        if (!message[0].StartsWith("<") || !message[0].EndsWith(">"))
            isValid = false;
    
        if (!message.Last().StartsWith("<END"))
            isValid = false;
    
        return isValid;
    }
    private bool IsReplyMessage(string[] message)
    {
        return message.Length>0 && message[0].StartsWith("<REPLY ");
    }
    private BasicAntwort ParseResponse(string[] message)
    {
        string header = message[0].Substring(7, message[0].Length - 8);
        return new BasicAntwort(message, header);
    }
