            private static void Main(string[] args)
            {
                for (int i = 0; i < 20; i++)
                {
                    Console.WriteLine(i);
                    Capture(i);
                }
            }
    
            private static void Capture(int index)
            {
                string Name = String.Format("dump-{0}.wav", index);
    
                using (WasapiCapture capture = new WasapiLoopbackCapture())
                {
                    capture.Initialize();
                    using (var w = new WaveWriter(Name, capture.WaveFormat))
                    {
                        capture.DataAvailable += (s, capData) => w.Write(capData.Data, capData.Offset, capData.ByteCount);
                        capture.Start();
    
                        Thread.Sleep(10000);
    
                        capture.Stop();
                    }
                }
            }
