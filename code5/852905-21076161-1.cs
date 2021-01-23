    namespace Tcp_Client
    {
        public partial class Form1 : Form
        {
            // Defind the TCP Client:
            TcpClient _Client = null;
            Stream _Stream = null;
        
            public Form1()
            {
                InitializeComponent();
            }
            private void btnConnect_Click(object sender, EventArgs e)
            {
                _Client = new TcpClient();
                // Connect the TCP Client:
                _Client.Connect("127.0.0.1", 7777);
                // Show the Client has Connected:
                listStatus.Items.Add("Connected to Server 127.0.0.1");
                // Create a Stream:                
                _Stream = _Client.GetStream();
            }
            private void btnSend_Click(object sender, EventArgs e)
            {
                if (_Client.Connected)
                {
                    // Create Instance of an Encoder:
                    ASCIIEncoding _Asc = new ASCIIEncoding();
                    byte[] _Buffer = new byte[1024];
                    // Create Buffer to Send Message:
                    _Buffer = _Asc.GetBytes(txtMessage.Text);
                    // Show Client is Sending Message:
                    listStatus.Items.Add("Tranmitting Message...");
                    // Write Message to the Stream:
                    _Stream.Write(_Buffer, 0, _Buffer.Length);
                }
            }
            private void btnDisconnect_Click(object sender, EventArgs e)
            {
                _Stream.Close();
                _Stream.Dispose();
                _Client.Close();
                listStatus.Items.Add("Disconnected from server.");
            }
        }
    }
