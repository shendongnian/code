    public class PacketReader
    {
        Socket MainSocket;
        public static void Main()
        {
            MainSocket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);                               // acts like MainSocket was never declared
    
            // Bind the socket to the selected IP address
            MainSocket.Bind(newIPEndPoint(IPAddress.Parse(cmbInterfaces.Text),0));
    
            // Set the socket options
            MainSocket.SetSocketOption(SocketOptionLevel.IP,  //Applies only to IP packets
                               SocketOptionName.HeaderIncluded, //Set the include header
                               true);                           //option to true
    
            byte[] byTrue = newbyte[4]{1, 0, 0, 0};
            byte[] byOut = newbyte[4];
    
            //Socket.IOControl is analogous to the WSAIoctl method of Winsock 2
            MainSocket.IOControl(IOControlCode.ReceiveAll,  //SIO_RCVALL of Winsock
                         byTrue, byOut);
    
            //Start receiving the packets asynchronously
            MainSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None,
                        newAsyncCallback(OnReceive), null);
        }
    }
