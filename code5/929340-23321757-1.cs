    if (client.Connected)
    {
        NetworkStream binarystream = client.GetStream();
        Stream file = File.OpenWrite(saveFileDialog1.FileName);
        byte[] buffer = new byte[10000];
        int bytesRead;
        while (binarystream.DataAvailable)
        {
            bytesRead = binarystream.Read(buffer, 0, buffer.Length);
            file.Write(buffer, 0, bytesRead);
        }
        file.Close();
        binarystream.Close();
    }
