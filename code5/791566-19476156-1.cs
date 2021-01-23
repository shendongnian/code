    class Client
        {
            private static void Main(string[] args)
            {
                Console.WriteLine("Press any key to start Client");
                while (! Console.KeyAvailable)
                {
                }
    
    
                TcpClient client = new TcpClient();
                client.Connect("127.0.0.1", 1500);
    
                NetworkStream networkStream = client.GetStream();
    
                // Create BinaryWriter for writing to stream
                BinaryWriter binaryWriter = new BinaryWriter(networkStream);
    
                // Creating BinaryReader for reading the stream
                BinaryReader binaryReader = new BinaryReader(networkStream);
    
                // Writing "test" to stream
                byte[] writeData = Encoding.ASCII.GetBytes("test");
                Array.Resize(ref writeData, 16); // Resizing to 16 bit, because in this example all messages have 16 bit to make it easier to understand.
                binaryWriter.Write(writeData, 0, 16);
    
                // Reading response and writing it to console
                byte[] responeBytes = new byte[16];
                binaryReader.Read(responeBytes, 0, 16);
                string response = Encoding.ASCII.GetString(responeBytes);
                Console.WriteLine("Server: " + response);
    
    
                while (true)
                {
                }
            }
        }
