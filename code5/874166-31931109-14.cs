    internal static class StreamingExtensions
    {
      public static ushort ReadUShort( this Stream stream )
      {
        return BitConverter.ToUInt16( ReadBytes( stream, 2 ), 0 );
      }
      public static uint ReadUInt( this Stream stream )
      {
        return BitConverter.ToUInt32( ReadBytes( stream, 4 ), 0 );
      }
      public static long ReadLong( this Stream stream )
      {
        return BitConverter.ToInt64( ReadBytes( stream, 8 ), 0 );
      }
      public static ulong ReadULong( this Stream stream )
      {
        return BitConverter.ToUInt64( ReadBytes( stream, 8 ), 0 );
      }
      public static byte[ ] ReadBytes( this Stream stream, int length, bool throwIfIncomplete = false )
      {
        var bytes = new byte[ length ];
        var bytesRead = 0;
        var offset = 0;
        if ( length > 0 )
        {
          while ( offset < length )
          {
            bytesRead = stream.Read( bytes, offset, length - offset );
            if ( bytesRead == 0 )
            {
              if ( throwIfIncomplete ) throw new InvalidOperationException( "incomplete" );
              break;
            }
            offset += bytesRead;
          }
        }
        return bytes;
      }
    }
