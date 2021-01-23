            TcpClient client = new TcpClient("127.0.0.1", 13579);
            string message = "one" + Environment.NewLine;
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
            NetworkStream stream = client.GetStream();
            stream.Write(data, 0, data.Length);
