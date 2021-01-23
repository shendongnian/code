    async Task Receive()
    {
        WebSocketReceiveResult result = await _Client.ReceiveAsync(_ClientBuffer, _CancellationToken);
        if (result.Count != 0 || result.CloseStatus == WebSocketCloseStatus.Empty)
        {
            string message = Encoding.ASCII.GetString(_ClientBuffer.Array,
                 _ClientBuffer.Offset, result.Count);
            OnReceiveMessage(message);
            await Receive();
        }
    }
