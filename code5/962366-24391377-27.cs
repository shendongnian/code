	// If file is mono then leave rightSamples null.
	public void WriteAudioData(FileStream stream, bool isStereo, int bitDepth, float[] leftSamples, float[] rightSamples = null)
	{
		float[] samples = null;
		if (isStereo)
		{
			samples = new float[leftSamples.Length + rightSamples.Length];
			leftSamples.CopyTo(samples, 0);
			rightSamples.CopyTo(samples, leftSamples.Length - 1);
		}
		else
		{
			samples = leftSamples;
		}
		switch (bitDepth)
		{
			case 8:
				{
					WriteSamples8Bit(stream, samples);
					break;
				}
			case 16:
				{
					WriteSamples16Bit(stream, samples);
					break;
				}
			case 24:
				{
					WriteSamples24Bit(stream, samples);
					break;
				}
			case 32:
				{
					WriteSamples32Bit(stream, samples);
					break;
				}
		}
	}
	private void WriteSamples8Bit(FileStream stream, float[] samples)
	{
		for (var i = 0; i < samples.Length; i++)
		{
			stream.WriteByte((byte)(samples[i] + 127));
		}
	}
	private void WriteSamples16Bit(FileStream stream, float[] samples)
	{
		for (var i = 0; i < samples.Length; i++)
		{
			stream.Write(BitConverter.GetBytes((short)samples[i]), 0, 2);
		}
	}
	private void WriteSamples24Bit(FileStream stream, float[] samples)
	{
		for (var i = 0; i < samples.Length; i++)
		{
			var bytes = BitConverter.GetBytes((int)samples[i]);
			stream.Write(new byte[] { bytes[0], bytes[1], bytes[2] }, 0, 3);
		}
	}
	private void WriteSamples32Bit(FileStream stream, float[] samples)
	{
		for (var i = 0; i < samples.Length; i++)
		{
			stream.Write(BitConverter.GetBytes(samples[i]), 0, 4);
		}
	}
 
