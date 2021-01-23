        using (var file = File.OpenWrite("myimage.png"))
        {
            do
            {
                bytes = s.Receive(bytesReceived, bytesReceived.Length, 0);
                file.Write(bytesReceived, 0, bytes);
            }
            while (bytes > 0);
            file.Close();
        }
