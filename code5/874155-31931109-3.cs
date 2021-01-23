    public unsafe static bool ReadMft( SafeHandle volume )
    {
      var outputBufferSize = 1024 * 1024;
      var input = new NativeMethods.MFTEnumDataV0( );
      var usnRecord = new NativeMethods.UsnRecordV2( );
      var outputBuffer = new byte[ outputBufferSize ];
      var okay = true;
      var doneReading = false;
      try
      {
        fixed ( byte* pOutput = outputBuffer )
        {
          input.StartFileReferenceNumber = 0;
          input.LowUsn = 0;
          input.HighUsn = long.MaxValue;
          using ( var stream = new MemoryStream( outputBuffer, true ) )
          {
            while ( !doneReading )
            {
              var bytesRead = 0U;
              okay = NativeMethods.DeviceIoControl
              (
                volume.DangerousGetHandle( ),
                NativeMethods.DeviceIOControlCode.FsctlEnumUsnData,
                ( byte* ) &input.StartFileReferenceNumber,
                ( uint ) Marshal.SizeOf( input ),
                pOutput,
                ( uint ) outputBufferSize,
                out bytesRead,
                IntPtr.Zero
              );
              if ( !okay )
              {
                var error = Marshal.GetLastWin32Error( );
                okay = error == NativeMethods.ERROR_HANDLE_EOF;
                if ( !okay )
                {
                  Console.WriteLine( "Crap! Windows error " + error.ToString( ) );
                  break;
                }
                else
                {
                  doneReading = true;
                }
              }
              input.StartFileReferenceNumber = stream.ReadULong( );
              while ( stream.Position < bytesRead )
              {
                usnRecord.Read( stream );
                //-->>>>>>>>>>>>>>>>> 
                //--> just an example of reading out the record...
                Console.WriteLine( "FRN:" + usnRecord.FileReferenceNumber.ToString( ) );
                Console.WriteLine( "Parent FRN:" + usnRecord.ParentFileReferenceNumber.ToString( ) );
                Console.WriteLine( "File name:" + usnRecord.FileName );
                Console.WriteLine( "Attributes: " + ( NativeMethods.EFileAttributes ) usnRecord.FileAttributes );
                Console.WriteLine( "Timestamp:" + usnRecord.TimeStamp );
                //-->>>>>>>>>>>>>>>>>>> 
              }
              stream.Seek( 0, SeekOrigin.Begin );
            }
          }
        }
      }
      catch ( Exception ex )
      {
        Console.Write( ex );
        okay = false;
      }
      return okay;
    }
