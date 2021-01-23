        static SIPTransport Transport;
        static SIPMessage msg;
        static string inputMsg;
        static SIPUDPChannel channel;
        static SIPRequest subscribeRequest;
 
        static void Main(string[] args)
        {
            InitializeSIP();
            Console.Read();
        }
 
        static void InitializeSIP()
        {
            //ResolveIPEndPoint
            SIPEndPoint sipep = new SIPEndPoint(new IPEndPoint(IPAddress.Parse("192.168.102.12"), 5060));
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse("192.168.102.12"), 5060);
 
            //Set Transport
            Transport = new SIPTransport(SIPDNSManager.ResolveSIPService, new SIPTransactionEngine());
 
            //IPEndPoint
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("192.168.100.10"), 8080);
 
            //Create Channel object
            channel = new SIPUDPChannel(localEndPoint);
            Transport.AddSIPChannel(channel);
 
            //Wire transport with incoming requests
            Transport.SIPTransportRequestReceived += new SIPTransportRequestDelegate(Transport_SIPTransportRequestReceived);
 
            //Wire transport with incoming responses
            Transport.SIPTransportResponseReceived += new SIPTransportResponseDelegate(Transport_SIPTransportResponseReceived);
 
            inputMsg = "SUBSCRIBE sip:myUSer@192.168.102.12 SIP/2.0" + SIPConstants.CRLF +
            "Via: SIP/2.0/UDP 192.168.100.10:8080;rport;branch=z9hG4bKFBB7EAC06934405182D13950BD51F001" + SIPConstants.CRLF +
            "From: <sip:subscribeUser@192.168.102.12>;tag=196468136" + SIPConstants.CRLF +
            "To: <sip:myUser@192.168.102.12>" + SIPConstants.CRLF +
            "Contact: <sip:subscribeUser@>" + SIPConstants.CRLF +
            "Call-ID: 1337505490-453410046-705466123" + SIPConstants.CRLF +
            "CSeq: 1 SUBSCRIBE" + SIPConstants.CRLF +
            "Max-Forwards: 70" + SIPConstants.CRLF +
            "Event: Presence" + SIPConstants.CRLF +
            "Content-Length: 0";
 
            subscribeRequest = SIPRequest.ParseSIPRequest(inputMsg);
 
            channel.Send(remoteEP, subscribeRequest.ToString());
        }
 
        static void Transport_SIPTransportResponseReceived(SIPEndPoint localSIPEndPoint, SIPEndPoint remoteEndPoint, SIPResponse sipResponse)
        {
            Console.WriteLine("Response method: " + sipResponse.Header.CSeqMethod);
            if(sipResponse.StatusCode == 401 && sipResponse.Header.CSeqMethod == SIPMethodsEnum.SUBSCRIBE)
            {
                                //Resubscribe with Digist
                //SIP Header
                SIPHeader header = subscribeRequest.Header;
                header.CSeq++;
                header.CallID = "some_new_callID";
                header.AuthenticationHeader = sipResponse.Header.AuthenticationHeader;
                header.Expires = 120;
 
                //New Request
                SIPRequest request = new SIPRequest(SIPMethodsEnum.SUBSCRIBE, new SIPURI(SIPSchemesEnum.sip, remoteEndPoint));
                request.LocalSIPEndPoint = localSIPEndPoint;
                request.RemoteSIPEndPoint = remoteEndPoint;
                request.Header = header;
 
                //Send request
                channel.Send(remoteEndPoint.GetIPEndPoint(), request.ToString());
            }
            else
                Console.WriteLine(string.Format("Error {0} {1}.", sipResponse.StatusCode, sipResponse.Status));
        }
 
        static void Transport_SIPTransportRequestReceived(SIPEndPoint localSIPEndPoint, SIPEndPoint remoteEndPoint, SIPRequest sipRequest)
        {
            Console.WriteLine("Request body: " + sipRequest.Body);
        }
