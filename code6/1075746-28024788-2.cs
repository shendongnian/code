        private void HandleClientThread(object obj)
        {
            TcpClient client = obj as TcpClient;
            netStream = client.GetStream();
            Console.WriteLine("Connection found!");
            while (true)
            {
                // read data
                byte[] buffer = new byte[1024];
                int totalRead = 0;
                do
                {
                    int read = client.GetStream().Read(buffer, totalRead, buffer.Length - totalRead);
                    totalRead += read;
                } while (client.GetStream().DataAvailable);
                string received = Encoding.ASCII.GetString(buffer, 0, totalRead);
                Console.WriteLine("\nResponse from client: {0}", received);
                // do some actions
                byte[] bytes = Encoding.ASCII.GetBytes(received);
                // send data back
                client.GetStream().WriteAsync(bytes, 0, bytes.Length);
            }
        }
