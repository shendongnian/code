    private async void streamSocketListener_ConnectionReceived(
        StreamSocketListener sender, StreamSocketListenerConnectionReceivedEventArgs args)
    {
        DataWriter writer = new DataWriter(args.Socket.OutputStream);
        writer.WriteString(responseHtml);
        await writer.StoreAsync();
        await writer.FlushAsync();
    }
