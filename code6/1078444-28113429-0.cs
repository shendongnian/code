        SerialPort serial = new SerialPort();
        static SerialPort cport;
        public Form1()
        {
            InitializeComponent();
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int i;
            try
            {
                string[] ports = SerialPort.GetPortNames();
                foreach(string newport in ports)
                {
                    cport = new SerialPort(newport, 9600);
                    cport.Open();
                    cport.WriteLine("A");
                    int intReturnASCII = serial.ReadByte();
                    char returnMessage = Convert.ToChar(intReturnASCII);
                    if (returnMessage == 'B')
                    {
                        button2.Enabled = true;
                        break;
                    }
                    else
                    {
                        cport.Close();
                    }
                }
            }
            catch (Exception )
            {
                Console.WriteLine("No COM ports found");
            }
        
        }
