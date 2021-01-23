    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    namespace ConsoleApplication2 {
    class Program {
      static void Main(string[] args) {
         ServerWorkThread objThread = new ServerWorkThread();
         while(true) {
            objThread.HandleConnection(objThread.mySocket.Accept());
         }
      }
    }
    public class ServerWorkThread {
         public Socket mySocket;
         public ServerWorkThread() {
            IPEndPoint objEnpoint = new IPEndPoint(IPAddress.Parse("10.101.3.72"), 8888);
            mySocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            mySocket.Bind(objEnpoint);
            mySocket.Listen(100);
         }
         public void HandleConnection(Socket iIncomingSocket) {
            Thread worker = new Thread(this.RecieveAndSend);
            worker.Start(iIncomingSocket);
            worker.Join();
         }
         public void RecieveAndSend(object iIncoming) {
            Socket objSocket = (Socket)iIncoming;
            byte[] bytes = new byte[1024];
            int bytesRecieved = objSocket.Receive(bytes);
            string strReceived = System.Text.Encoding.ASCII.GetString(bytes, 0, bytesRecieved);
            Console.WriteLine("Received from client: " + strReceived);
            Console.WriteLine("Sending acknowledgement to client");
            string strSend = ("Command of: " + strReceived + " was processed successfully");
            objSocket.Send(System.Text.Encoding.ASCII.GetBytes(strSend));
            objSocket.Close();
         }
      }
