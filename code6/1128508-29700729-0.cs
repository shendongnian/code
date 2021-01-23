        using System;
        using System.Collections.Generic;
        using System.ComponentModel;
        using System.Data;
        using System.Drawing;
        using System.Linq;
        using System.Net;
        using System.Net.Sockets;
        using System.Text;
        using System.Threading.Tasks;
        using System.Windows.Forms;
        namespace WindowsFormsApplication1 {
        public partial class Form1 : Form {
            private Socket serverSocket;
            public Form1() {
                InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e) {
                StartListening();
            }
            private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
                serverSocket.Close();
            }
            public void StartListening() {
                byte[] bytes = new byte[1024];
                IPAddress ipAddress = IPAddress.Parse(serverIpAddress);
                IPEndPoint localEndPoint = new IPEndPoint(ipAddress, portNumber);
         
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try {
                  serverSocket.Bind(localEndPoint);
                  serverSocket.Listen(100);
                  while(true) {
                     allDone.Reset();
               
                     Console.WriteLine("Waiting for a connection...");
                     serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), serverSocket);
               // wait until a connection is made before continuing
                     allDone.WaitOne();
                   }
                 }
                 catch(Exception e) {
                     Console.WriteLine(e.ToString());
                 }
                finally {
                     serverSocket.Close();
                }
                Console.WriteLine("\nPress ENTER to continue...");
                Console.Read();
         }
          }
        }
