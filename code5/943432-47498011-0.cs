    try
    {
    	WebSocketReceiveResult result;
    	string receivedMessage = "";
    	var message = new ArraySegment<byte>(new byte[4096]);
    	do
    	{
    		result = await WebSocket.ReceiveAsync(message, DisconectToken);
    		if (result.MessageType != WebSocketMessageType.Text)
    			break;
    		var messageBytes = message.Skip(message.Offset).Take(result.Count).ToArray();
    		receivedMessage += Encoding.UTF8.GetString(messageBytes);                    
    	}
    	while (!result.EndOfMessage);
    	if (receivedMessage != "{}" && !string.IsNullOrEmpty(receivedMessage))
    	{
    		ResolveWebSocketResponse.Invoke(receivedMessage, Connection);
    		Console.WriteLine("Received: {0}", receivedMessage);
    	}
    }
    catch (Exception ex)
    {
    	var mes = ex.Message;
    }
