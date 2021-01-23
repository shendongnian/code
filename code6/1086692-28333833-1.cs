    static async Task Receive(ClientWebSocket socket)
    {
        try
        {
            byte[] recvBuffer = new byte[64 * 1024];
            while (socket.State == WebSocketState.Open || socket.State == WebSocketState.CloseSent)
            {
                var result = await socket.ReceiveAsync(new ArraySegment<byte>(recvBuffer), CancellationToken.None);
                Console.WriteLine("Client got {0} bytes", result.Count);
                Console.WriteLine(Encoding.UTF8.GetString(recvBuffer, 0, result.Count));
                if (result.MessageType == WebSocketMessageType.Close)
                {
                    Console.WriteLine("Close loop complete");
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception in receive - {0}", ex.Message);
        }
    }
