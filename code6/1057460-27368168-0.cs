        private string OpenMedia(string filename)
        {
            using (var reader = new WaveFileReader(filename))
            {
                int bitrate = reader.WaveFormat.AverageBytesPerSecond * 8;
                if (bitrate > 128000)
                {
                    MessageBox.Show("This wav file has a bit rate higher than 128 kbps : " +
        bitrate);
                    int channel = reader.WaveFormat.Channels;
                    if (channel > 1)
                    {
                        MessageBox.Show("This wav file was not created in Mono channel : " +
        channel);
                    }
                    int samplerate = reader.WaveFormat.SampleRate;
                    if (samplerate > 8000)
                    {
                        MessageBox.Show("This wav file has a sample rate > 8000 : " + samplerate);
                        var newFormat = new WaveFormat(8000, 16, 1);
                        using (var conversionStream = new WaveFormatConversionStream(newFormat,
        reader))
                        {
                            WaveFileWriter.CreateWaveFile(filename, conversionStream);
                        }
                    }
                }
            }
            return filename;
        }
