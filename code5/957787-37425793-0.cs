            string sq = /* URL of WAV file (http://foo.com/blah.wav) */
            using (WebClient wc = new WebClient())
            {
                string fx = Guid.NewGuid().ToString("N") + DateTime.Now.Ticks.ToString();
                string fileName = Server.MapPath("/") + "file-" + fx + ".wav";
                string tfileName = Server.MapPath("/") + "file-" + fx + "-2.wav";
                string xfileName = Server.MapPath("/") + "file-" + fx + ".mp3";
                wc.DownloadFile(sq.Trim(), fileName);
                if (!sq.ToLower().EndsWith(".wav"))
                {
                    xfileName = fileName;
                }
                else
                {
                    using (var ms = new MemoryStream(File.ReadAllBytes(fileName)))
                    {
                        using (var mp3ms = new MemoryStream())
                        {
                            using (var wavReader = new WaveFileReader(ms))
                            {
                                if (wavReader.WaveFormat.BitsPerSample == 8)
                                {
                                    var newFormat = new WaveFormat(wavReader.WaveFormat.SampleRate, 16, 2);
                                    using (var convWave = new WaveFormatConversionStream(newFormat, wavReader))
                                    {
                                        WaveFileWriter.CreateWaveFile(tfileName, convWave);
                                    }
                                    using (var mx = new MemoryStream(File.ReadAllBytes(tfileName)))
                                    {
                                        using (var wavReaderx = new WaveFileReader(mx))
                                        {
                                            using (var wavWriter = new LameMP3FileWriter(xfileName, wavReaderx.WaveFormat, LAMEPreset.ABR_128))
                                            {
                                                wavReaderx.CopyTo(wavWriter);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    using (var wavWriter = new LameMP3FileWriter(xfileName, wavReader.WaveFormat, LAMEPreset.ABR_128))
                                    {
                                        wavReader.CopyTo(wavWriter);
                                    }
                                }
                            }
                        }
                    }
                }
                Response.ContentType = "audio/mpeg";
                Response.WriteFile(xfileName);
                Response.End();
            }
        }
