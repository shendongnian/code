    try {
        static object[] messageAsArray = { "dummy" };
        object[0] = message;
        this.Invoke(new WriteLineHandler(printMessage), new object[] { message });
    }
        catch (Exception)
    {
                }
