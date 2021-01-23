    private static void Main(string[] args)
    {
        using(var capture = new WasapiCapture())
        {
            capture.Initialize();
            using(var source = new SoundInSource(capture))
            {
                using(var soundOut = new WasapiOut())
                {
                    capture.Start();
                    soundOut.Initialize(source);
                    soundOut.Play();
                    Console.ReadKey();
                }
            }
        }
    }
