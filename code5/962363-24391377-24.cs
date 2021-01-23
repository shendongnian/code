	private void ReadMetaData(FileStream stream)
	{
		var CID = new byte[4];         // Chunk ID data.
		var SC1SData = new byte[4];    // Sub-chunk 1 size data.
		var AFData = new byte[2];      // Audio format data.
		var CHData = new byte[2];      // Channel count data.
		var SRData = new byte[4];      // Sample rate data.
		var BPSData = new byte[2];     // Bits per sample data.
		var INFOCIDData = new byte[4]; // INFO Chunk ID data.
		var INFOCSData = new byte[4];  // INFO Chunk size data.
		var bytes = new byte[200];     // Header bytes.
		// Read header bytes.
		stream.Position = 0;
		stream.Read(bytes, 0, 200);
		// Read chunk ID.
		stream.Position = 0;
		stream.Read(CID, 0, 4);
		if (Encoding.ASCII.GetString(CID) != "RIFF") { throw new Exception("File is not a recognised wav file."); }
		// Read sub-chunk 1 size.
		stream.Position = 16;
		stream.Read(SC1SData, 0, 4);
		// Read audio format.
		stream.Position = 20;
		stream.Read(AFData, 0, 2);
		// Read channel count.
		stream.Position = 22;
		stream.Read(CHData, 0, 2);
		// Read sample rate.
		stream.Position = 24;
		stream.Read(SRData, 0, 4);
		// Read bit depth.
		stream.Position = 34;
		stream.Read(BPSData, 0, 2);
		var header = new string(Encoding.ASCII.GetChars(bytes));
		// You'll need to pass these variables back to the caller somehow; or assign them to global variables/public properties if you're going to use this in a class.
		var HeaderSize = (uint)header.IndexOf("data") + 8;
		var Format = BitConverter.ToUInt16(AFData, 0);
		var Channels = BitConverter.ToUInt16(CHData, 0);
		var SampleRate = BitConverter.ToUInt32(SRData, 0);
		var BitDepth = BitConverter.ToUInt16(BPSData, 0);
		var AudioLengthBytes = (uint)(stream.Length - HeaderSize);
		stream.Position = 0;
	}
