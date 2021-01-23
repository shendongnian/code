        private Bitmap DrawSpectrogram(string fileName, int height, int stepsPerSecond)
        {
            Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, Handle);
            int channel = Bass.BASS_StreamCreateFile(fileName, 0, 0, BASSFlag.BASS_DEFAULT);
            long len = Bass.BASS_ChannelGetLength(channel, BASSMode.BASS_POS_BYTES); // the length in bytes
            double time = Bass.BASS_ChannelBytes2Seconds(channel, len); // the length in seconds
            int steps = (int)Math.Floor(stepsPerSecond * time);
            Bitmap result = new Bitmap(steps, height);
            Graphics g = Graphics.FromImage(result);
            Visuals visuals = new Visuals();
            Bass.BASS_ChannelPlay(channel, false);
            for (int i = 0; i < steps; i++)
            {
                Bass.BASS_ChannelSetPosition(channel, 1.0 * i / stepsPerSecond);
                visuals.CreateSpectrum3DVoicePrint(channel, g, new Rectangle(0, 0, result.Width, result.Height), Color.Black, Color.White, i, true, false);
            }
            Bass.BASS_ChannelStop(channel);
            Bass.BASS_Stop();
            Bass.BASS_Free();
            return result;
        }
