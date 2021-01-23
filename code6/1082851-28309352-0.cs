        public string inputTo;
        public string outputFrom;
        public string Server { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public static SshClient client { get; set; }
        public ShellStream shellStream { get; set; }
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Server = textBox1.Text;
                Username = textBox2.Text;
                Password = textBox3.Text;
                client = new SshClient(Server, Username, Password);
                client.Connect();
                string reply = string.Empty;
                shellStream = client.CreateShellStream("dumb", 80, 24, 800, 600, 1024);
                reply = shellStream.Expect(new Regex(@":.*>#"), new TimeSpan(0, 0, 3));
                richTextBox1.Text = "Connected please enter command\r\n#";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CheckKeys(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                 ShellRunner();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            client.Disconnect();
            client.Dispose();
        }
        public void ShellRunner()
        {
            try
            {
                var reader = new StreamReader(shellStream);
                int totalLines = richTextBox1.Lines.Length;
                inputTo = richTextBox1.Lines[totalLines - 2];                
                int i  = inputTo.LastIndexOf("#");
                if (i != -1){ shellStream.WriteLine(inputTo.Substring(i + 1)); }
                else { shellStream.WriteLine(inputTo); }
                string result = shellStream.ReadLine(new TimeSpan(0, 0, 3));
                outputFrom = reader.ReadToEnd();
                richTextBox1.AppendText(outputFrom);            
             }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
