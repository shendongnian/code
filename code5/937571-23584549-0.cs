    byte[] data   = SomeData();
    byte[] length = System.BitConverter.GetBytes(data.Length);
    byte[] buffer = new byte[data.Length + length.Length];
    int offset = 0;
    // Encode the length into the buffer.
    System.Buffer.BlockCopy(length, 0, buffer, offset, length.Length);
    offset += length.Length;
    // Encode the data into the buffer.
    System.Buffer.BlockCopy(data, 0, buffer, offset, data.Length);
    offset += data.Length;  // included only for symmetry
    // Initialize your socket connection.
    System.Net.Sockets.TcpClient client = new ...;
    // Get the stream.
    System.Net.Sockets.NetworkStream stream = client.GetStream();
    // Send your data.
    stream.Write(buffer, 0, buffer.Length);
