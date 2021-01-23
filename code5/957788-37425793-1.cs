            string sq = /* URL of WAV file (http://foo.com/blah.wav) */
            Response.ContentType = "audio/mpeg";
            using (WebClient wc = new WebClient())
            {
                if (!sq.ToLower().EndsWith(".wav"))
                {
                    byte[] rawFile = wc.DownloadData(sq.Trim());
                    Response.OutputStream.Write(rawFile, 0, rawFile.Length);
                }
                else
                {
                    using (var wavReader = new WaveFileReader(new MemoryStream(wc.DownloadData(sq.Trim()))))
                    {
                        try
                        {
                            using (var wavWriter = new LameMP3FileWriter(Response.OutputStream, wavReader.WaveFormat, LAMEPreset.ABR_128))
                            {
                                wavReader.CopyTo(wavWriter);
                            }
                        }
                        catch (ArgumentException)
                        {
                            var newFormat = new WaveFormat(wavReader.WaveFormat.SampleRate, 16, 2);
                            using (var pcmStream = new WaveFormatConversionStream(newFormat, wavReader))
                            {
                                using (var wavWriter = new LameMP3FileWriter(Response.OutputStream, pcmStream.WaveFormat, LAMEPreset.ABR_128))
                                {
                                    pcmStream.CopyTo(wavWriter);
                                }
                            }
                        }
                    }
                }
                Response.Flush();
                Response.End();
            }
