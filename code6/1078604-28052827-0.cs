        static void Main()
        {
            //creating object for file transfer
            using (NamedPipeServerStream pipeServer =
                new NamedPipeServerStream("File Transfer", PipeDirection.Out))
            {
                Console.WriteLine("File Transfer Named Pipe Stream is ready...");
                Console.Write("Waiting for client connection...");//waiting for any client connections
                pipeServer.WaitForConnection();
                Console.WriteLine("Client connected.");
                try
                {
                    string strFile = @"c:\Test\1\Srinivas.txt";
                    using (BinaryWriter writer = new BinaryWriter(pipeServer, Encoding.UTF8, true))
                    {
                        writer.Write(strFile);
                    }
                    //opening the source file to read bytes
                    using (FileStream fs = File.Open(strFile, FileMode.Open, FileAccess.Read))
                    {
                        fs.CopyTo(pipeServer);
                    }
                }
                // Catch the IOException that is raised if the pipe is
                // broken or disconnected.
                catch (IOException e)
                {
                    Console.WriteLine("ERROR: {0}", e.Message);
                }
            }
        }
