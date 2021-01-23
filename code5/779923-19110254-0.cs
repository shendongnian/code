		public static Byte[] WavToMP3(byte[] wavFile)
		{
			using (MemoryStream source = new MemoryStream(wavFile))
			using (NAudio.Wave.WaveFileReader rdr = new NAudio.Wave.WaveFileReader(source))
			{
				WaveLib.WaveFormat fmt = new WaveLib.WaveFormat(rdr.WaveFormat.SampleRate, rdr.WaveFormat.BitsPerSample, rdr.WaveFormat.Channels);
				
				// convert to MP3 at 96kbit/sec...
				Yeti.Lame.BE_CONFIG conf = new Yeti.Lame.BE_CONFIG(fmt, 96);
				// Allocate a 1-second buffer
				int blen = rdr.WaveFormat.AverageBytesPerSecond;
				byte[] buffer = new byte[blen];
				// Do conversion
				using (MemoryStream output = new MemoryStream())
				{ 
					Yeti.MMedia.Mp3.Mp3Writer mp3 = new Yeti.MMedia.Mp3.Mp3Writer(output, fmt, conf);
					int readCount;
					while ((readCount = rdr.Read(buffer, 0, blen)) > 0)
						mp3.Write(buffer, 0, readCount);
					mp3.Close();
					return output.ToArray();
				}
			}
		}
