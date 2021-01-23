	// totalSampleCount needs to be the combined count of samples of all channels. So if the left and right channels contain 1000 samples each, then totalSampleCount should be 2000.
	// isFloatingPoint should only be true if the audio data is in 32-bit floating-point format.
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
