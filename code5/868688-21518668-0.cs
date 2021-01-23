    string message = null;
    string[] messageLines = commMessage.Split('\n');
    
    foreach (string messageLine in messageLines)
    {
        String formattedLine;
        if (messageLine.Length > 60)
        {
             formattedLine = messageLine.Insert(messageLine.LastIndexOf(' ', 60), "\n");
        }
        else
        {
             formattedLine = messageLine;
        }
    
        message += formattedLine;
    }
