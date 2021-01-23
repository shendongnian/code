	private void ReadMetaData(FileStream stream, out bool isFloatinfPoint, out int channelCount, out int sampleRate, out int bitDepth, out int headerSize)
	{
		var headerBytes = new byte[200];
		// Read header bytes.
		stream.Position = 0;
		stream.Read(headerBytes, 0, 200);
		headerSize = new string(Encoding.ASCII.GetChars(headerBytes)).IndexOf("data") + 8;
		isFloatinfPoint = BitConverter.ToUInt16(new byte[] { headerBytes[20], headerBytes[21] }, 0) == 3 ? true : false;
		channelCount = BitConverter.ToUInt16(new byte[] { headerBytes[22] , headerBytes[23] }, 0);
		sampleRate = (int)BitConverter.ToUInt32(new byte[] { headerBytes[24], headerBytes[25], headerBytes[26], headerBytes[27] }, 0);
		bitDepth = BitConverter.ToUInt16(new byte[] { headerBytes[34], headerBytes[35] }, 0);
	}
