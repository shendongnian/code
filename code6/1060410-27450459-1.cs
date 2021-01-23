    static void processWave(string fileIn, string fileOut, float newTempo = 1.4f, float newPitch = 1, float newRate = 1)
    {
        using (WaveFileReader reader = new WaveFileReader(fileIn))
		{
			int numChannels = reader.WaveFormat.Channels, sampleRate = reader.WaveFormat.SampleRate;
			int bitPerSample = reader.WaveFormat.BitsPerSample;
			const int BUFFER_SIZE = 1024 * 16;
			SoundStretcher stretcher = new SoundStretcher(sampleRate, numChannels);
			
			using (WaveFileWriter writer = new WaveFileWriter(fileOut, new WaveFormat(sampleRate, 16, numChannels)))
			{
				stretcher.Tempo = newTempo;
				stretcher.Pitch = newPitch;
				stretcher.Rate = newRate;
				byte[] buffer = new byte[BUFFER_SIZE];
				short[] buffer2 = null;
				if (bitPerSample == 8)
					buffer2 = new short[BUFFER_SIZE];
				bool finished = false;
				while (true)
				{
					int bytesRead = 0;
					if (!finished)
					{
						bytesRead = reader.Read(buffer, 0, BUFFER_SIZE);
						if (bytesRead == 0)
						{
							finished = true;
							stretcher.Flush();
						}
						else
						{
							if (bitPerSample == 16)
								stretcher.PutSamplesFromBuffer(buffer, 0, bytesRead);
							else if (bitPerSample == 8)
							{
								for (int i = 0; i < BUFFER_SIZE; i++)
									buffer2[i] = (short)((buffer[i] - 128) * 256);
								stretcher.PutSamples(buffer2);
							}
						}
					}
					bytesRead = stretcher.ReceiveSamplesToBuffer(buffer, 0, BUFFER_SIZE);
					writer.WriteData(buffer, 0, bytesRead);
					if (finished && bytesRead == 0)
						break;
				}
				writer.Close();
			}
			
			reader.Close();
		}
    }
    private void Form1_Load(object sender, EventArgs e)
    {
		for (int i = 1; i <= 2; i++)
        {
            processWave("D:\\us1.wav", "D:\\vs2.wav");
            WaveOut obj = new WaveOut();
			
            using (WaveFileReader h = new WaveFileReader("D:\\vs2.wav"))
			{
				obj.Init(h);
				obj.Play();
			}
        }
	
		/*
        processWave("D:\\us1.wav","D:\\vs2.wav");
        WaveOut obj = new WaveOut();
        
		using (WaveFileReader h = new WaveFileReader("D:\\vs2.wav"))
		{
			obj.Init(h);
			obj.Play();
		}
		*/
    }
