        static void Main(string[] args)
        {
            //connecting to the known pipe stream server which runs in localhost
            using (NamedPipeClientStream pipeClient =
                new NamedPipeClientStream(".", "File Transfer", PipeDirection.In))
            {
                // Connect to the pipe or wait until the pipe is available.
                Console.Write("Attempting to connect to File Transfer pipe...");
                //time out can also be specified
                pipeClient.Connect();
                Console.WriteLine("Connected to File Transfer pipe.");
                using (BinaryReader reader = new BinaryReader(pipeClient, Encoding.UTF8, true))
                {
                    string fileName = reader.ReadString();
                }
                //creating the target file with name same as specified in source which comes using
                //file transfer object
                using (FileStream fs = new FileStream(@"c:\Test\2\" + fileName, FileMode.Create, FileAccess.Write))
                {
                    pipeClient.CopyTo(fs);
                }
                Console.WriteLine("File, Received from server: {0}", fileName);
            }
            Console.Write("Press Enter to continue...");
            Console.ReadLine();
        }
