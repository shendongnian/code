    async Task ReceiveFromPipe(Stream pipeStream, int bufferSize)
    {
        Action action;
        while ((action = await ReceivePoint2D(pipeStream, bufferSize)) != null)
        {
            action();
        }
    }
    async Task<Action> ReceivePoint2D(Stream pipeStream, int bufferSize)
    {
        byte[] buffer = new byte[bufferSize];
        int byteCount;
        while ((byteCount = await pipeStream
            .ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false)) > 0)       
        {
            int type;
            string message;
            if (TryCompleteMessage(buffer, byteCount, out type, out message))   
            {
                return PipeClientMessageReceived(type, message);
            }
        }
        return null;
    }
    public Action PipeClientMessageReceived(int type, string message)
    {
        var command = (PipeCommand)type;
        switch (command)
        {
            case PipeCommand.Points:
                {
                    string[] tokens = message.Split(':');
                    var x = Convert.ToDouble(tokens[0]);
                    var y = Convert.ToDouble(tokens[1]);
                    return () => SetSlotCoordinates(new Point2D(x, y)); 
                }
                break;
        }
    }
