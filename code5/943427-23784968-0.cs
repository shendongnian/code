    ArraySegment<Byte> buffer = new ArraySegment<byte>(new Byte[8192]);
    WebSocketReceiveResult result= null;
    using (var ms = new MemoryStream())
    {
         do
         {
             result = await socket.ReceiveAsync(buffer, CancellationToken.None);
             ms.Write(buffer.Array, buffer.Offset, result.Count);
         }
         while (!result.EndOfMessage);
         ms.Seek(0, SeekOrigin.Begin);
         if (result.MessageType == WebSocketMessageType.Text)
         {
              using (var reader = new StreamReader(ms, Encoding.UTF8))
              {
                   // do stuff
              }
         }
    }
