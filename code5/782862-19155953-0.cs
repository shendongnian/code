    static void Receiver( )
    {
    	Console.WriteLine( "Receiving..." );
    	var udpClient = new UdpClient( 667 );
    	var endPoint = new IPEndPoint( IPAddress.Any, 0 );
    	byte[] data = udpClient.Receive( ref endPoint );
    	Console.WriteLine( "Received '{0}'.", Encoding.UTF8.GetString( data ) );
    	udpClient.Close( );
    }
