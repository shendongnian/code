    public class PacketHandler
    {
        public static BlockingCollection<string> LogData = new BlockingCollection<string>();
        private static void StartListening()
        {
            if (!isInitialized) Initialize();
            try
            {
                listener.Start();
                while (true)
                {
                    client = listener.AcceptTcpClient();
                    // some kind of logging here which reaches the ui immediately
                    LogData.TryAdd("log"); //adding a log entry to the logData, completely thread safe
                    var protocol = new Protocol(client);
                    var thread = new Thread(protocol.StartCommunicating) { IsBackground = true };
                    thread.Start();
                    connectedThreads.Add(thread);
                }
            }
            catch (Exception)
            {
                // temp
                MessageBox.Show("Error in PacketHandler class");
            }
        }
    }
