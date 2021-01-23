		LameMP3FileWriter mp3writer = null;
		WaveFormat mp3format = null;
		public void StartMP3Encoding(string filename, WaveFormat format)
		{
			if (mp3writer != null)
				StopMP3Encoding();
			mp3format = format;
			mp3writer = new LameMP3FileWriter(filename, format, 128);
		}
		public void StopMP3Encoding()
		{
			if (mp3writer != null)
			{
				mp3writer.Dispose();
				mp3writer = null;
			}
		}
		public int EnqueueSamples(int channels, int rate, byte[] samples, int frames)
		{
			if (mp3writer != null && mp3format.Channels == channels)
				mp3writer.Write(samples, 0, samples.Length);
			return frames;
		}
