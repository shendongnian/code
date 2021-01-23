    class Server
        {
            static void Main(string[] args)
            {
                TcpListener listener = new TcpListener(IPAddress.Any, 1500);
                listener.Start();
    
                TcpClient client = listener.AcceptTcpClient();
    
                NetworkStream stream = client.GetStream();
    
                // Create BinaryWriter for writing to stream
                BinaryWriter binaryWriter = new BinaryWriter(stream);
    
                // Creating BinaryReader for reading the stream
                BinaryReader binaryReader = new BinaryReader(stream);
    
                while (true) 
                {
                    // Read incoming information
                    byte[] data = new byte[16];
                    int receivedDataLength = binaryReader.Read(data, 0, data.Length);
                    string stringData = Encoding.ASCII.GetString(data, 0, receivedDataLength);
    
                    // Write incoming information to console
                    Console.WriteLine("Client: " + stringData);
    
                    // Respond to client
                    byte[] respondData = Encoding.ASCII.GetBytes("respond");
                    Array.Resize(ref respondData, 16); // Resizing to 16 byte, because in this example all messages have 16 byte to make it easier to understand.
                    binaryWriter.Write(respondData, 0, 16);
                }
    
            }
        }
