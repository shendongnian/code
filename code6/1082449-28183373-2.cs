    static string GetLastResponse(string message, string delimeter = "From:")
    {
        int delimeterPosition = message.IndexOf(delimeter);
        return (delimeterPosition > -1)
            ? message.Substring(0, delimeterPosition)
            : message;
    }
