    namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                using(var f = new Form2())
                {
                    f.ShowDialog();
                }
            }
        }
    }
        namespace WindowsFormsApplication2
    {
        public partial class Form2 : Form
        {
            public const string SERVER_IP = "192.168.5.1";
            public const int PORT_NO = 3999;
            public Form2()
            {
                InitializeComponent();
                var t = Task.Factory.StartNew(() => Listener());
            }
    
            private void ExecuteSecure(Action a)
            {
                if (InvokeRequired)
                    BeginInvoke(a);
                else
                    a();
            }
    
            private void Listener()
            {
    
                //---listen at the specified IP and port no.---
                IPAddress localAdd = IPAddress.Parse(SERVER_IP);
                TcpListener listener = new TcpListener(localAdd, PORT_NO);
                listener.Start();
                while (true)
                {
                    listen(listener);
                }
            }
    
            private void listen(TcpListener listener)
            {
    
                //---incoming client connected---
                TcpClient client = listener.AcceptTcpClient();
    
                //---get the incoming data through a network stream---
                NetworkStream nwStream = client.GetStream();
                byte[] buffer = new byte[client.ReceiveBufferSize];
    
                //---read incoming stream---
                int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);
    
                //---convert the data received into a string---
                var dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                
                //we are listening on a different thread so we cannot show a msgbox directly.
                ExecuteSecure(() => MessageBox.Show(dataReceived + " har fået et anfald mkay", "Patient har fået anfald mkay", MessageBoxButtons.OK, MessageBoxIcon.Error));
                //---write back the text to the client---
    
                client.Close();
            }
    
        }
    }  
 
