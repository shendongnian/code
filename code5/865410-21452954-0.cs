    static void Main(string[] args)
    {
		SIPTCPChannel channel_Tcp = new SIPTCPChannel(new IPEndPoint(IPAddress.Any, 5060));
		var Transport = new SIPTransport(SIPDNSManager.ResolveSIPService, new SIPTransactionEngine());
		Transport.AddSIPChannel(channel_Tcp);
		IPEndPoint sipServerEndPoint = new IPEndPoint(IPAddress.Parse("0.0.0.0"), 5060);
		Timer keepAliveTimer = new Timer(30000);
		keepAliveTimer.Elapsed += (sender, e) =>
		{
			// If the TCP channel still has a connection to the SIP server socket then send a dummy keep-alive packet.
			if(channel_Tcp.IsConnectionEstablished(sipServerEndPoint))
			{
				channel_Tcp.Send(sipServerEndPoint, new byte[] { 0x00, 0x00, 0x00, 0x00 });
			}
			else
			{
				keepAliveTimer.Enabled = false;
			}
		};
		keepAliveTimer.Enabled = true;
    }
