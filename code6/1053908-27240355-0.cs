    public Form1()
    {
        InitializeComponent();
    }
    //Variables
    TcpClient client;
    StreamReader sr;
    StreamWriter sw;
    //Functions
    public void connect(string host)
    {
        client = new TcpClient(host, 6667);
        sr = new StreamReader(client.GetStream());
        sw = new StreamWriter(client.GetStream());
    }
    public void write(string str)
    {
        textBox1.Text += str;
    }
    public void sendData(string str)
    {
        sw.WriteLine(str);
        sw.Flush();
    }
    public async Task listener()
    {
        try
        {
            string data
            while ((data = await sr.ReadLineAsync()) != null)
            {
                write(data);
            }
        }
        catch (ObjectDisposedException)
        {
            // socket was closed forcefully
        }
    }
    //End Functions
    private void Form1_Load(object sender, EventArgs e)
    {
        //Initialize
        write("Welcome to LogernIRC. Type \"/help\" for help with commands.\r\n");
    }
    private void button1_Click(object sender, EventArgs e) //Submit button clicked
    {
        //TextBox 1 is the text area , textbox 2 is the message/command area
        //Command Area
        if (textBox2.Text == "/help")
        {
            write("Help:\r\n/connect Connect to IRC server\r\n/help Display this help menu\r\n/join Join channel");
        }
        if (textBox2.Text.StartsWith("/connect"))
        {
            write("\r\nConnecting to " + textBox2.Text.Split(' ')[1] + " on port 6667...");
            connect(textBox2.Text.Split(' ')[1]);
        }
        if (textBox2.Text.StartsWith("/join"))
        {
            write("\r\nJoining channel " + textBox2.Text.Split(' ')[1]);
        }
        if (textBox2.Text == "/test")
        {
            connect("irc.freenode.net");
            // initiate async reading (storing the returned Task in a variable
            // prevents the compiler from complaining that we don't await the
            // call).
            var _ = listener();
            write("\r\nActivating test function...");
            sendData("NICK Logern");
            sendData("USER Logern 0 * :LOGERN");
        }
    }
