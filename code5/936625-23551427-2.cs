    public class RawSocketPing
    {
        public Socket pingSocket;             // Raw socket handle
        public int pingTtl;                // Time-to-live value to set on ping
        public ushort pingId;                 // ID value to set in ping packet
        public ushort pingSequence;           // Current sending sequence number
        public int pingPayloadLength;      // Size of the payload in ping packet
        public int pingCount;              // Number of times to send ping request
        public int pingReceiveTimeout;     // Timeout value to wait for ping response
        private IPEndPoint destEndPoint;           // Destination being pinged
        public IPEndPoint responseEndPoint;       // Contains the source address of the ping response
        public EndPoint castResponseEndPoint;   // Simple cast time used for the responseEndPoint
        private byte[] pingPacket;             // Byte array of ping packet built
        private byte[] pingPayload;            // Payload in the ping packet
        private byte[] receiveBuffer;          // Buffer used to receive ping response
        private IcmpHeader icmpHeader;             // ICMP header built (for IPv4)
        private DateTime pingSentTime;       // Timestamp of when ping request was sent
       
        /// <summary>
        /// Base constructor that initializes the member variables to default values. It also
        /// creates the events used and initializes the async callback function.
        /// </summary>
        public RawSocketPing()
        {
            pingSocket = null;
            pingTtl = 8;
            pingPayloadLength = 8;
            pingSequence = 0;
            pingReceiveTimeout = 2000;
            destEndPoint = new IPEndPoint(IPAddress.Loopback, 0);
            icmpHeader = null;
        }
        /// <summary>
        /// Constructor that overrides several members of the ping packet such as TTL,
        /// payload length, ping ID, etc.
        /// </summary>
        /// <param name="af">Indicates whether we're doing IPv4 or IPv6 ping</param>
        /// <param name="ttlValue">Time-to-live value to set on ping packet</param>
        /// <param name="payloadSize">Number of bytes in ping payload</param>
        /// <param name="sendCount">Number of times to send a ping request</param>
        /// <param name="idValue">ID value to put into ping header</param>
        public RawSocketPing(
            int ttlValue,
            int payloadSize,
            int sendCount,
            ushort idValue
            )
            : this()
        {
            pingTtl = ttlValue;
            pingPayloadLength = payloadSize;
            pingCount = sendCount;
            pingId = idValue;
        }
        /// <summary>
        /// This routine is called when the calling application is done with the ping class.
        /// This routine closes any open resource such as socket handles.
        /// </summary>
        public void Close()
        {
            try
            {
                
                if (pingSocket != null)
                {
                    pingSocket.Close();
                    pingSocket = null;
                }
            }
            catch (Exception err)
            {
                
                throw;
            }
        }
        /// <summary>
        /// Since ICMP raw sockets don't care about the port (as the ICMP protoocl has no port
        /// field), we require the caller to just update the IPAddress of the destination 
        /// although internally we keep it as an IPEndPoint since the SendTo method requires
        /// that (and the port is simply set to zero).
        /// </summary>
        public IPAddress PingAddress
        {
            get
            {
                return destEndPoint.Address;
            }
            set
            {
                destEndPoint = new IPEndPoint(value, 0);
            }
        }
        /// <summary>
        /// This routine initializes the raw socket, sets the TTL, allocates the receive
        /// buffer, and sets up the endpoint used to receive any ICMP echo responses.
        /// </summary>
        public void InitializeSocket()
        {
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, 0);
            // Create the raw socket
                
            pingSocket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.Icmp);
            // Socket must be bound locally before socket options can be applied
                
            pingSocket.Bind(localEndPoint);
            pingSocket.SetSocketOption(
                SocketOptionLevel.IP,
                SocketOptionName.IpTimeToLive,
                pingTtl
                );
            // Allocate the buffer used to receive the response
            pingSocket.ReceiveTimeout = pingReceiveTimeout;     
            receiveBuffer = new byte[540];
            responseEndPoint = new IPEndPoint(IPAddress.Any, 0);
            castResponseEndPoint = (EndPoint)responseEndPoint;
        }
        /// <summary>
        /// This routine builds the appropriate ICMP echo packet depending on the
        /// protocol family requested.
        /// </summary>
        public void BuildPingPacket()
        {
            // Initialize the socket if it hasn't already been done
            
            if (pingSocket == null)
            {
                InitializeSocket();
            }
            // Create the ICMP header and initialize the members
            icmpHeader = new IcmpHeader() 
                { Id = pingId, Sequence = pingSequence, Type = IcmpHeader.EchoRequestType, Code = IcmpHeader.EchoRequestCode };
            // Build the data payload of the ICMP echo request
                
            pingPayload = new byte[pingPayloadLength];
            for (int i = 0; i < pingPayload.Length; i++)
            {
                pingPayload[i] = (byte)'e';
            }
        }
        /// <summary>
        /// This function performs the actual ping. It sends the ping packets created to
        /// the destination 
        /// </summary>
        public bool DoPing()
        {
            bool success = false;
            
            // Send an echo request
            while (pingCount > 0)
            {
                try
                {
                    pingCount--;
                    // Increment the sequence count in the ICMP header
                    icmpHeader.Sequence = (ushort)(icmpHeader.Sequence + (ushort)1);
                    // Build the byte array representing the ping packet. This needs to be done
                    //    before ever send because we change the sequence number (which will affect
                    //    the calculated checksum).
                    pingPacket = icmpHeader.BuildPacket(pingId, pingPayload);
                    // Mark the time we sent the packet
                    pingSentTime = DateTime.Now;
                    // Send the echo request
                    pingSocket.SendTo(pingPacket, destEndPoint);
                    int Brecieved = pingSocket.ReceiveFrom(
                        receiveBuffer,
                        0,
                        receiveBuffer.Length,
                        SocketFlags.None,
                        ref castResponseEndPoint
                        );
                    
                    //IF you get to here, then you got a response.
                    success = true;
                    break;
                    
                }
                catch (SocketException  err)
                {
                    //PING FAILED, try it again for remaining ping counts
                }
            }
            return success;    
        }
     
    }
