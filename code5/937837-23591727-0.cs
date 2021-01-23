        IWaveSource source = CodecFactory.Instance.GetCodec(@"C:\Temp\test.mp3");
        using (var fadeInOut = new FadeInOut(source, 1.0f))
        {
            using (var soundOut = new WasapiOut())
            {
                soundOut.Initialize(fadeInOut.ToWaveSource());
                soundOut.Play();
                
                Thread.Sleep(1000);
                fadeInOut.StartFading(2, 0.0f); //reduce the volume to 0.0f over 2 seconds
                Thread.Sleep(3000);
                fadeInOut.StopFading(); //stop fading
                fadeInOut.StartFading(2, 1.0f); //fade the volume to 1.0f over 2 seconds
                Console.ReadKey();
            }
        }
