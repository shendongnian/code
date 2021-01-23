    static async void ReadAsync(TcpClient client)
    {
        NetworkStream ns = client.GetStream();
        MemoryStream ms = new MemoryStream();
        byte[] buffer = new byte[1024];
        while(true) {
            int bytesRead = await ns.ReadAsync(buffer, 0, buffer.Length);
            if (bytesRead <= 0)
                break;
            ms.Write(buffer, 0, bytesRead);
            HandleMessage(ms.ToArray());
            ms.Seek(0, SeekOrigin.Begin);
        }
    }
