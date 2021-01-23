        using(TcpClient client = new TcpClient(_server, _port))
        using(NetworkStream stream = client.GetStream())
        using(MemoryStream output = new MemoryStream())
        {
            stream.CopyTo(output);
            return output.ToArray();
        }
