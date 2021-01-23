    public class PrintHelper
    {
        private readonly IPAddress PrinterIPAddress;
        private readonly byte[] FileData;
        private readonly int PortNumber;
        private ManualResetEvent connectDoneEvent { get; set; }
        private ManualResetEvent sendDoneEvent { get; set; }
        public PrintHelper(byte[] fileData, string printerIPAddress, int portNumber = 9100)
        {
            FileData = fileData;
            PortNumber = portNumber;
            if (!IPAddress.TryParse(printerIPAddress, out PrinterIPAddress))
                throw new Exception("Wrong IP Address!");
        }
        public PrintHelper(byte[] fileData, IPAddress printerIPAddress, int portNumber = 9100) 
        {
            FileData = fileData;
            PortNumber = portNumber;
            PrinterIPAddress = printerIPAddress;
        }
        /// <inheritDoc />
        public bool PrintData()
        {
            //this line is Optional for checking before send data
            if (!NetworkHelper.CheckIPAddressAndPortNumber(PrinterIPAddress, PortNumber))
                return false;
            IPEndPoint remoteEP = new IPEndPoint(PrinterIPAddress, PortNumber);
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            client.NoDelay = true;
            connectDoneEvent = new ManualResetEvent(false);
            sendDoneEvent = new ManualResetEvent(false);
            try
            {
                client.BeginConnect(remoteEP, new AsyncCallback(connectCallback), client);
                connectDoneEvent.WaitOne();
                client.BeginSend(FileData, 0, FileData.Length, 0, new AsyncCallback(sendCallback), client);
                sendDoneEvent.WaitOne();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                // Shutdown the client
                this.shutDownClient(client);
            }
        }
        private void connectCallback(IAsyncResult ar)
        {
            // Retrieve the socket from the state object.
            Socket client = (Socket)ar.AsyncState;
            // Complete the connection.
            client.EndConnect(ar);
            // Signal that the connection has been made.
            connectDoneEvent.Set();
        }
        private void sendCallback(IAsyncResult ar)
        {
            // Retrieve the socket from the state object.
            Socket client = (Socket)ar.AsyncState;
            // Complete sending the data to the remote device.
            int bytesSent = client.EndSend(ar);
            // Signal that all bytes have been sent.
            sendDoneEvent.Set();
        }
        private void shutDownClient(Socket client)
        {
            client.Shutdown(SocketShutdown.Both);
            client.Close();
        }
    }
