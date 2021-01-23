    class Program
    {
        static void Main(string[] args)
        {
            MyClass mc = new MyClass();
        }
    }
    
    public class MyClass
    {
        //Creates a UdpClient for reading incoming data.
        private UdpClient udpClient;
        private UdpClient recipient;
        private Thread thread;
        private const String IPADDR = "127.0.0.1";
    
        public MyClass()
        {
            recipient = new UdpClient(new IPEndPoint(IPAddress.Parse(IPADDR), 12000));
            this.thread = new Thread(new ThreadStart(this.Execute));
            this.thread.Name = "Udp";
            this.thread.Start();
    
            udpClient = new UdpClient(11000);
            udpClient.Connect(IPAddress.Parse(IPADDR), 12000);
            SendData("The quick brown fox jumps over the lazy dog");
        }
    
        private void Execute()
        {
            try
            {
                // Blocks until a message returns on this socket from a remote host.
                IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Parse(IPADDR), 11000);
                    
                Byte[] receiveBytes = this.recipient.Receive(ref remoteIpEndPoint);
    
                Console.WriteLine("Data received: " + Encoding.ASCII.GetString(receiveBytes));
    
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    
    
        public void SendData(String data)
        {
            Console.WriteLine("Sending...");
            try
            {
                this.udpClient.Send(System.Text.Encoding.ASCII.GetBytes(data), data.Length);
            }
            catch (Exception e)
            {
                Console.WriteLine(String.Format("Exception {0}", e.Message));
            }
       }
    }
