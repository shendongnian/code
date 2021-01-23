    NetworkStream stream = m_client.GetStream();   //m_client is a TCPclient
    using (MemoryStream buffer = new MemoryStream())
    using (StreamWriter writer = new StreamWriter(buffer))
    {
        int[] a = new int[3] { 10,20,30 };
        XmlSerializer serializer = new XmlSerializer(typeof(int[]));
        serializer.Serialize(writer, a);
        // This code assumes you aren't sending more than 2GB of XML.
        // This allows the other end to use int instead of long for the
        // length to receive.
        byte[] lengthBytes = BitConverter.GetBytes((int)buffer.Length);
        stream.Write(lengthBytes, 0, lengthBytes.Length);
        buffer.Position = 0;
        buffer.CopyTo(stream);
    }
