    using System;
    using System.Text;
    using System.Windows.Forms;
    using System.Threading;
    using System.Net.Sockets;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            TcpClient clientSocket;
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click_1(object sender, EventArgs e)
            {
                clientSocket = new TcpClient("127.0.0.1", 8001); // Note the change
                Thread Listener = new Thread(ServerListener);
                Listener.Start();
            }
    
            public void ServerListener()
            {
                byte[] buf;
                Console.WriteLine("Thread started");
           
                NetworkStream serverStream = clientSocket.GetStream();
                while (true)
                {
                    Console.WriteLine("this");
                    if (serverStream.DataAvailable)
                    {
                        buf = new byte[clientSocket.ReceiveBufferSize];
                        serverStream.Read(buf, 0, buf.Length);
                        string stringdata = Encoding.ASCII.GetString(buf);
                        Console.WriteLine("Received message: " + stringdata);
    
                        switch (stringdata)
                        {
                            case "ping":
                                buf = Encoding.ASCII.GetBytes("pong");
                                Console.WriteLine("Sent pong");
                                serverStream.Write(buf, 0, buf.Length);
                                serverStream.Flush();
                                break;
                            case "handshake":
                                buf = Encoding.ASCII.GetBytes("lol");
                                Console.WriteLine("Sent confirmation");
                                serverStream.Write(buf, 0, buf.Length);
                                serverStream.Flush();
                                break;
                        }
    
                    }
                }
            }
        }
    }
