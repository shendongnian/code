    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    namespace Client {
    class Program {
      static void Main(string[] args) {
         ClientWorkThread thread1 = new ClientWorkThread("I am thread 1");
         thread1.SendCommand();
         ClientWorkThread thread2 = new ClientWorkThread("I am thread 2");
         thread2.SendCommand();
         ClientWorkThread thread3 = new ClientWorkThread("I am thread 3");
         thread3.SendCommand();
         Console.Read();
      }
    }
   
      public class ClientWorkThread {
         private Socket pSocket;
         private string command;
         public ClientWorkThread(string iCommand) {
            IPEndPoint objEnpoint = new IPEndPoint(IPAddress.Parse("10.101.3.72"), 8888);
            pSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            pSocket.Connect(objEnpoint);
            command = iCommand;
         }
         public void SendCommand() {
            Thread worker = new Thread(this.Send);
            worker.Start(pSocket);
         }
         public void Send(object iSending) {
            Socket objSocket = (Socket)iSending;
            objSocket.Send(System.Text.Encoding.ASCII.GetBytes(command + " now DO WORK "));
            Console.WriteLine("Sending: " + command + " now DO WORK ");
            byte[] bytes = new byte[1024];
            int bytesRecieved = objSocket.Receive(bytes);
            string strReceived = System.Text.Encoding.ASCII.GetString(bytes, 0, bytesRecieved);
            Console.WriteLine("Received from server: " + strReceived);
            objSocket.Close();
         }
      }
    }
