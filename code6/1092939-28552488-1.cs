    async Task ProcessLines()
    {
        using (StreamReader reader = new StreamReader(
            this.networkStream, Encoding.UTF8, false, 1024, true))
        {
            string line;
            while ((line = await reader.ReadLineAsync()) != null)
            {
                this.processOutput(line);
            }
        }
        // Clean up here. I.e. send any remaining response to remote endpoint,
        // call Socket.Shutdown(SocketShutdown.Both), and then close the
        // socket.
    }
