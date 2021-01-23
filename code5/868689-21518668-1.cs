    StringBuilder message = new StringBuilder();
    string[] messageLines = commMessage.Split('\n');
    
    foreach (string messageLine in messageLines)
    {
        if (messageLine.Length > 60)
        {
             message.Append(messageLine.Insert(messageLine.LastIndexOf(' ', 60), "\n"));
        }
        else
        {
             message.Append(messageLine);
        }
    }
    // do something with message.ToString()
