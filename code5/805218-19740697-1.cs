    try {
        static object[] messageAsArray = { "dummy" };
        messageAsArray[0] = message;
        this.Invoke(new WriteLineHandler(printMessage), messageAsArray);
    }
        catch (Exception)
    {
                }
