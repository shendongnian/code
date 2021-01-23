    namespace Client_Form
    {
        public partial class Client_Form : Form
        {
            TcpClient client = null;
            NetworkStream stream = null;
            int count = 0;
    
            public Client_Form()
            {
                InitializeComponent();
            }
            protected override void OnLoad(EventArgs e)
            {
                // Handling the network operations after the form loads ensures
                // that the asynchronous operations will come back to the main
                // thread as desired.
                // Ignore returned Task
                var _ = Start_Program();
            }
    
            private async void Start_Program()
            {
                try
                {
                    // Connect to server
                    client = await Task.Run(() => new TcpClient("127.0.0.1", 8080));
                    textBox.Text = "<Connected to server>";
    
                    stream = client.GetStream();
    
                    byte[] buffer = new byte[256];
                    int q_count = 5;
    
                    while (count < q_count)
                    {
                        textBox.Text = "Waiting for other client";
                        // Get data from server
                        int byteRecv = await stream.ReadAsync(buffer, 0, buffer.Length);
                        string message = Encoding.ASCII.GetString(buffer, 0, byteRecv);
    
                        Co_Game_Question.Text = message;
    
                    }
    
                    // Close stream and connection
                    stream.Close();
                    client.Close();
    
                    textBox.Text = "<Connection closed>";
                }
                catch (SocketException se)
                {
                    textBox.Text = "Error Message: " + se.Message;
                }
            }
        }
    }
