    TcpClient client = (TcpClient)p_client;
    NetworkStream stream = client.GetStream();
    
    // Using BinaryReader is easier than implementing a correct, blocking read
    // of fixed numbers of bytes -- TCP can return as little as a single byte for
    // any given receive operation, but BinaryReader insulates us from that.
    // Leave the stream open so that we can read more later.
    using (BinaryReader binary = new BinaryReader(stream, Encoding.UTF8, true))
    {
        int length = binary.ReadInt32();
        byte[] buffer = binary.ReadBytes(length);
    
        using (MemoryStream streamBuffer = new MemoryStream(buffer))
        using (StreamReader reader = new StreamReader(streamBuffer))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(int[]));
            int[] numbers = (int[])serializer.Deserialize(reader);
            MessageBox.Show(numbers[0].ToString());    //Is not reached
            MessageBox.Show(numbers[1].ToString());
            MessageBox.Show(numbers[2].ToString());
        }
    }
