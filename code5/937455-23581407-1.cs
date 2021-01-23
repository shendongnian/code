    public partial class Form1 : Form
    {
        string ipAdress = "192.168.1.74";
        int port = 9997;
        TcpClient tcpClient = new TcpClient();
        NetworkStream networkStream = null;
        StreamWriter streamWriter;
        public Form1()
        {
            InitializeComponent();            
        }
        
        private string GetCheckSum(string data)
        {
            int checksum = 0;
            for (int i = 0; i < data.Length; i++)
            {
                checksum ^= Convert.ToByte(data[i]);
            }
            return checksum.ToString("X2");
        }
      
        private void CreateConnection()
        {
            try
            {
                tcpClient.Connect(ipAdress, port);
                networkStream = tcpClient.GetStream();
                streamWriter = new StreamWriter(networkStream);
                if (tcpClient.Connected)
                {
                    pictureBox1.Image = Image.FromFile(@"Resources\Aqua-Ball-Green-icon.png");
                    Console.Write("Connected");
                }
                else
                    MessageBox.Show("Restart");
            }
            catch (Exception excep)
            {
                Console.WriteLine("Error.. " + excep.StackTrace);
            }
        }
        
        private void ReadData()
        {
            //receiving server response 
            byte[] bytes = new byte[1024];
            if (networkStream.CanRead)
            {
                int bytesRead = networkStream.Read(bytes, 0, bytes.Length);                   
                //received response, now encoding it to a string from a byte array
                Console.WriteLine("odgovor" + Encoding.UTF8.GetString(bytes, 0, bytesRead));
            }
            else
            {
                Console.WriteLine("You cannot read data from this stream.");
                tcpClient.Close();
                // Closing the tcpClient instance does not close the network stream.
                networkStream.Close();
            }
        }
        private void SendData(string command)
        {
            if (networkStream.CanWrite)
            {
                // Does a simple write.
                Byte[] sendBytes = Encoding.UTF8.GetBytes("Is anybody there");
                networkStream.Write(sendBytes, 0, sendBytes.Length);
                networkStream.Close();
                tcpClient.Close();
            }
            else if (!networkStream.CanWrite)
            {
                Console.WriteLine("You can not read data from this stream");
                tcpClient.Close();
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            CreateConnection();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            ReadData();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            SendData();
        }
    }
