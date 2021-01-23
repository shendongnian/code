    public static byte[] ConvertWavToMp3(byte[] wavFile)
            {
                
                using(var retMs = new MemoryStream())
                using (var ms = new MemoryStream(wavFile))
                using(var rdr = new WaveFileReader(ms))
                using (var wtr = new LameMP3FileWriter(retMs, rdr.WaveFormat, 128))
                {
                    rdr.CopyTo(wtr);
                    return retMs.ToArray();
                }
    
    
            }
