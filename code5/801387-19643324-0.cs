    byte[] octets ;
    Encoding someEncoding = new UTF8Encoding(false) ;
    
    using( MemoryStream aMemoryStream = new MemoryStream(8192) ) // let's start with 8k
    using ( BinaryWriter writer = new BinaryWriter( aMemoryStream , someEncoding ) ) // wrap that puppy in a binary writer
    {
      byte[] prefix = { 0x02 , 0x00 , 0x35 , 0x37 , 0xFF , } ;
      byte[] suffix = { 0x00 , 0x03 , } ;
      
      writer.Write( prefix ) ;
      writer.Write( "OF=TEST" );
      writer.Write( suffix ) ;
      octets = aMemoryStream.ToArray() ;
    }
    
    foreach ( byte octet in octets )
    {
      Console.WriteLine( "0x{0:X2}" , octet ) ;
    }
