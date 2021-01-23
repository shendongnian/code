    using System;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    var request  = WebRequest.Create( "http://example.com/file.dat" );
    var response = request.GetResponse();
    var client = new TcpClient();
    client.Connect( "127.0.0.1", 1234 );
    using( var sourceStream      = response.GetResponseStream() )
    using( var destinationStream = client.GetStream() )
    {
        sourceStream.CopyTo( destinationStream );
    }
