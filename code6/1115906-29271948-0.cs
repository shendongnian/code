    async Task ProcessMessage()
    {
        byte[] buffer = new byte[4096];
        rawMessage = string.Empty;
        while (true)
        {
            Array.Clear(buffer, 0, buffer.Length);
            int bytesRead = await networkStream.ReadAsync(buffer, 0, buffer.Length);
            rawMessage += (System.Text.Encoding.ASCII.GetString(buffer).Replace("\0", string.Empty));
            if (bytesRead == 0 || buffer[buffer.Length - 1] == 0)
            {
                StoreMessage();
                return;
            }
        }
    }
