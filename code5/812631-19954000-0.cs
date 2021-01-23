    string i_clob1 = "";
    string i_clob2 = "";
    string i_clob3 = "";
    if (message.Length >= 3 && message.Length <= 32000 * 3)
    {
        int lastStart = 2 * message.Length / 3;
        int lastLength = message.Length - lastStart;
        i_clob1 = message.Substring(0, message.Length / 3);
        i_clob2 = message.Substring(message.Length / 3, message.Length / 3);
        i_clob3 = message.Substring(lastStart, lastLength);
    }
    else if (message.Length < 3)
    {
        i_clob1 = message;
    }
