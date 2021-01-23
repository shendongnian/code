    public void WavToMp3(string wavPath, string fileId)
        {
            var tempMp3Path = TempPath + "tempFiles\\" + fileId + ".mp3";
            var mp3strm = new FileStream(tempMp3Path, FileMode.Create);
            try
            {
                using (var reader = new WaveFileReader(wavPath))
                {
                    var blen = 65536;
                    var buffer = new byte[blen];
                    int rc;
                    var bit16WaveFormat = new WaveFormat(16000, 16, 1);
                    using (var conversionStream = new WaveFormatConversionStream(bit16WaveFormat, reader))
                    {
                        var targetMp3Format = new WaveLib.WaveFormat(16000, 16, 1);
                        using (var mp3Wri = new Mp3Writer(mp3strm, new Mp3WriterConfig(targetMp3Format, new BE_CONFIG(targetMp3Format,64))))
                        {
                            while ((rc = conversionStream.Read(buffer, 0, blen)) > 0) mp3Wri.Write(buffer, 0, rc);
                            mp3strm.Flush();
                            conversionStream.Close();
                        }
                    }
                    reader.Close();
                }
                File.Move(tempMp3Path, TempPath + fileId + ".mp3");
            }
            finally
            {
                mp3strm.Close();
            }
        }
