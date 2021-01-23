    public partial class Sample : Form
        {
            public Sample()
            {
                InitializeComponent();
                CmdConnect(txtIPAddr.Text, txtPort.Text);
            }
    
            private void cmdConnect_Click(object sender, System.EventArgs e)
            {
                CmdConnect(txtIPAddr.Text, txtPort.Text);
            }
    
            private void CmdConnect(string txtIPAddr, string txtPort)
            {
                try
                {
                    EnableCommands(true);
                    //Creating instance of Socket
                    m_socClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    
                    // retrieve the remote machines IP address
                    IPAddress ip = IPAddress.Parse(txtIPAddr);
                    //A printer has open port 9100 which can be used to connect to printer
                    int iPortNo = System.Convert.ToInt16(txtPort);
                    //create the end point 
                    IPEndPoint ipEnd = new IPEndPoint(ip.Address, iPortNo);
                    //connect to the remote host
                    m_socClient.Connect(ipEnd);
                    EnableCommands(false);
                    //wait for data to arrive 
                    WaitForData();
                }
                catch (SocketException se)
                {
                    MessageBox.Show(se.Message);
                    EnableCommands(true);
                }
                page_counter();
            }
    
    // Other Methods
    }
