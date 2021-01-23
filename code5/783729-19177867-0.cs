        public byte[] ConvertWavToMP3(byte[] bt, uint bitrate)
        {         
            MemoryStream ms = new MemoryStream(bt);
            ms.Seek(0, SeekOrigin.Begin);
            var ws = new WaveFileReader(ms);
                          
            byte[] wavdata = null;
            using (MemoryStream wavstrm = new MemoryStream())
            using (WaveFileWriter wavwri = new WaveFileWriter(wavstrm, ws.WaveFormat))
            {
                ws.CopyTo(wavwri);
                wavdata = wavstrm.ToArray();
            }
            
            WaveLib.WaveFormat fmt = new WaveLib.WaveFormat(ws.WaveFormat.SampleRate, ws.WaveFormat.BitsPerSample, ws.WaveFormat.Channels);
            
            Yeti.Lame.BE_CONFIG beconf = new Yeti.Lame.BE_CONFIG(fmt, bitrate);
            byte[] srm = null;
            using (MemoryStream mp3strm = new MemoryStream())
            using (Mp3Writer mp3wri = new Mp3Writer(mp3strm, fmt, beconf))
            {               
                mp3wri.Write(wavdata, 0, wavdata.Length);
                byte[] mp3data = mp3strm.ToArray();
                return mp3data;
            }
           }
