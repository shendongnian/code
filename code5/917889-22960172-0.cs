    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    using System.Net;
    using System.Net.Sockets;
    
     namespace ClassLibrary2
     {
        public class take_off
        {
            public void testfunction()
            {
                UdpClient udpClient = new UdpClient(5556);
                IPAddress ipAddress = IPAddress.Parse("192.168.1.1");
                IPEndPoint sending_end_point = new IPEndPoint(ipAddress, 5556);
                int seq = 0;
    
                for(int i=0; i<30; i++) 
                {    
                    seq = seq + 1;
                    System.Console.WriteLine("send landing command");
                    string buff1= String.Format("AT*REF={0},290717696\r",seq);
                    byte[] bytesToSend = Encoding.ASCII.GetBytes(buff1);
                    udpClient.Send(bytesToSend,bytesToSend.Length,sending_end_point);
                }
            }
        }
    }
