    string request = default(string);
    StringBuilder sb = new StringBuilder();
    byte[] buffer = new  byte[client.ReceiveBufferSize];
    int bytesCount;
    if (client.GetStream().CanRead)
    {
        do
        {
            bytesCount = client.GetStream().ReadAsync(buffer, 0, buffer.Length).Result;
            sb.Append(Encoding.UTF8.GetString(buffer, 0, bytesCount));
        }
        while(client.GetStream().DataAvailable);
        request = sb.ToString();
    }
