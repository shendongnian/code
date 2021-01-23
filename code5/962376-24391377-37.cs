	private void CropWavFile(string inputFilePath, string outputFilePath, TimeSpan start, TimeSpan end)
	{
		var stream = new FileStream(inputFilePath, FileMode.Open);
		var newStream = new FileStream(outputFilePath, FileMode.OpenOrCreate);
		var isFloatingPoint = false;
		var sampleRate = 0;
		var bitDepth = 0;
		var channelCount = 0;
		var headerSize = 0;
        // Get meta info
		ReadMetaData(stream, out isFloatingPoint, out channelCount, out sampleRate, out bitDepth, out headerSize);
        // Calculate where we need to start and stop reading.
		var startIndex = (int)(start.TotalSeconds * sampleRate * (bitDepth / 8) * channelCount);
		var endIndex = (int)(end.TotalSeconds * sampleRate * (bitDepth / 8) * channelCount);
		var bytesCount = endIndex - startIndex;
		var newBytes = new byte[bytesCount];
        // Read audio data.
		stream.Position = startIndex + headerSize;
		stream.Read(newBytes, 0, bytesCount);
        // Write the wav header and our newly extracted audio to the new wav file.
		WriteMetaData(newStream, isFloatingPoint, (ushort)channelCount, (ushort)bitDepth, sampleRate, newBytes.Length / (bitDepth / 8));
		newStream.Write(newBytes, 0, newBytes.Length);
		stream.Dispose();
		newStream.Dispose();
	}
	private void WriteMetaData(FileStream stream, bool isFloatingPoint, ushort channels, ushort bitDepth, int sampleRate, int totalSampleCount)
	{
		stream.Position = 0;
		// RIFF header.
		// Chunk ID.
		stream.Write(Encoding.ASCII.GetBytes("RIFF"), 0, 4);
		// Chunk size.
		stream.Write(BitConverter.GetBytes(((bitDepth / 8) * totalSampleCount) + 36), 0, 4);
		// Format.
		stream.Write(Encoding.ASCII.GetBytes("WAVE"), 0, 4);
		// Sub-chunk 1.
		// Sub-chunk 1 ID.
		stream.Write(Encoding.ASCII.GetBytes("fmt "), 0, 4);
		// Sub-chunk 1 size.
		stream.Write(BitConverter.GetBytes(16), 0, 4);
		// Audio format (floating point (3) or PCM (1)). Any other format indicates compression.
		stream.Write(BitConverter.GetBytes((ushort)(isFloatingPoint ? 3 : 1)), 0, 2);
		// Channels.
		stream.Write(BitConverter.GetBytes(channels), 0, 2);
		// Sample rate.
		stream.Write(BitConverter.GetBytes(sampleRate), 0, 4);
		// Bytes rate.
		stream.Write(BitConverter.GetBytes(sampleRate * channels * (bitDepth / 8)), 0, 4);
		// Block align.
		stream.Write(BitConverter.GetBytes((ushort)channels * (bitDepth / 8)), 0, 2);
		// Bits per sample.
		stream.Write(BitConverter.GetBytes(bitDepth), 0, 2);
		// Sub-chunk 2.
		// Sub-chunk 2 ID.
		stream.Write(Encoding.ASCII.GetBytes("data"), 0, 4);
		// Sub-chunk 2 size.
		stream.Write(BitConverter.GetBytes((bitDepth / 8) * totalSampleCount), 0, 4);
	}
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
