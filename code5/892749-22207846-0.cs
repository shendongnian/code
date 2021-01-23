    var maxLength = 50; // set to desired value
    var strippedMessage = exception.Message;
    strippedMessage = strippedMessage.Replace("\n", string.Empty); // removes newline char
    strippedMessage = strippedMessage.Replace("\r", string.Empty); // removes carriage return char
    if (strippedMessage.Length > maxLength)
        strippedMessage = strippedMessage.Substring(0, maxLength - 3) + "..."; // reduces the message's size
