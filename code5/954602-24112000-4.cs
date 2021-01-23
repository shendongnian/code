    async Task<string> ReadAllAsync()
    {
        var sb = new StringBuffer();
    
        using (var tcp = new TcpClient())
        {
            await tcp.ConnectAsync(IPAddress.Parse("localhost"), 8080).ConfigureAwait(false);
            var buffer = new byte[1024];
            using (var stream = tcp.GetStream())
            {
                var bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                if (0 == bytesRead)
                    break;
                sb.Append(Encoding.ASCII.GetString(state.buffer,0,bytesRead));
            }
        }
    
        return sb.ToString();
    }
