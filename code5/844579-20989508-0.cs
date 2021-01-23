    public static byte[] Inflate(byte[] data)
        {
            int outputSize = 1024;
            byte[] output = new Byte[ outputSize ];
            bool expectRfc1950Header = true;
            using ( MemoryStream ms = new MemoryStream())
            {
                ZlibCodec compressor = new ZlibCodec();
                compressor.InitializeInflate(expectRfc1950Header);
                compressor.InputBuffer = data;
                compressor.AvailableBytesIn = data.Length;
                compressor.NextIn = 0;
                compressor.OutputBuffer = output;
                foreach (var f in new FlushType[] { FlushType.None, FlushType.Finish } )
                {
                    int bytesToWrite = 0;
                    do
                    {
                        compressor.AvailableBytesOut = outputSize;
                        compressor.NextOut = 0;
                        compressor.Inflate(f);
                        bytesToWrite = outputSize - compressor.AvailableBytesOut ;
                        if (bytesToWrite > 0)
                            ms.Write(output, 0, bytesToWrite);
                    }
                    while (( f == FlushType.None && (compressor.AvailableBytesIn != 0 || compressor.AvailableBytesOut == 0)) ||
                        ( f == FlushType.Finish && bytesToWrite != 0));
                }
                compressor.EndInflate();
                return ms.ToArray();
            }
        }
        public static byte[] Deflate(byte[] data)
        {
            int outputSize = 1024;
            byte[] output = new Byte[ outputSize ];
            int lengthToCompress = data.Length;
            // If you want a ZLIB stream, set this to true.  If you want
            // a bare DEFLATE stream, set this to false.
            bool wantRfc1950Header = true;
            using ( MemoryStream ms = new MemoryStream())
            {
                ZlibCodec compressor = new ZlibCodec();
                compressor.InitializeDeflate(CompressionLevel.BestCompression, wantRfc1950Header);  
                compressor.InputBuffer = data;
                compressor.AvailableBytesIn = lengthToCompress;
                compressor.NextIn = 0;
                compressor.OutputBuffer = output;
                foreach (var f in new FlushType[] { FlushType.None, FlushType.Finish } )
                {
                    int bytesToWrite = 0;
                    do
                    {
                        compressor.AvailableBytesOut = outputSize;
                        compressor.NextOut = 0;
                        compressor.Deflate(f);
                        bytesToWrite = outputSize - compressor.AvailableBytesOut ;
                        if (bytesToWrite > 0)
                            ms.Write(output, 0, bytesToWrite);
                    }
                    while (( f == FlushType.None && (compressor.AvailableBytesIn != 0 || compressor.AvailableBytesOut == 0)) ||
                        ( f == FlushType.Finish && bytesToWrite != 0));
                }
                compressor.EndDeflate();
                ms.Flush();
                return ms.ToArray();
            }
        }
