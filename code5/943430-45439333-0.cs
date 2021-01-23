    // Read the bytes from the web socket and accummulate into a list.
    var buffer = new ArraySegment<byte>(new byte[1024]);
    WebSocketReceiveResult result = null;
    var allBytes = new List<byte>();
    do
    {
        result = await webSocket.ReceiveAsync(buffer, CancellationToken.None);
        for (int i = 0; i < result.Count; i++)
        {
            allBytes.Add(buffer.Array[i]);
        }
    }
    while (!result.EndOfMessage);
    
    // Optional step to convert to a string (UTF-8 encoding).
    var text = Encoding.UTF8.GetString(allBytes.ToArray(), 0, allBytes.Count);
