    private static Task<MessageWebSocket> messageWebSocket = null;
    public static Task<MessageWebSocket> mws()
    {
        if (messageWebSocket == null)
            messageWebSocket = CreateMessageWebSocket();
        return  messageWebSocket;
    }
    private static async Task<MessageWebSocket> CreateMessageWebSocket()
    {
        var ret = new MesesageWebSocket();
        await ret.ConnectAsync();
        return ret;
    }
    private async Task websocketRequestRegisterDevice(object sender, TappedRoutedEventArgs e)
    {
        ...
        cos.WriteRawBytes(new byte[] { 7, 1, 0, 0 });
        req.WriteTo(cos);
        var s = await mws();
        s.Control.MessageType = SocketMessageType.Binary;
        s.MessageReceived += websocketResponseRegisterDevice;
        messageWriter = new DataWriter(s.OutputStream);
        messageWriter.WriteBytes(buff);
        await messageWriter.StoreAsync();
    }
