    class Program
    {
        class Chunk
        {
            public int Size { get; set; }
            public byte[] Data { get; set; }
        }
        static void Main(string[] args)
        {
            try
            {
                int buffersize = 1024;
                TcpListener server = new TcpListener(IPAddress.Any, 13000);
                server.Start();
                var chunks = new List<Chunk>();
                while (true)
                {
                    byte[] bytes = new byte[buffersize];
                    TcpClient client = server.AcceptTcpClient();
                    NetworkStream stream = client.GetStream();
                    int i;
                    i = stream.Read(bytes, 0, bytes.Length);
                    chunks.Add(new Chunk{Size = i, Data = bytes});
                    while (i != 0)
                    {
                        byte[] leBytes = new byte[buffersize];
                        i = stream.Read(leBytes, 0, leBytes.Length);
                        chunks.Add(new Chunk{Size = i, Data = bytes});
                    }
                    client.Close();
                    int totalSize = chunks.Select(x => x.Size).Sum();
                    var allData = new byte[totalSize];
                    int offset = 0;
                    foreach(var chunk in chunks)
                    {
                        Buffer.BlockCopy(chunk.Data,0,allData,offset,chunk.Size);
                        offset += chunk.Size;
                    }
                }
            }
            catch (SocketException e)
            {
            }
        }
    }
