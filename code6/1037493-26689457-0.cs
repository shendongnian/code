    class PlaySound
    {
        IWavePlayer wave;
        AudioFileReader file;
        
        public PlaySound(string FILE)
        {
           file = new AudioFileReader(FILE);
           wave = new WaveOut();
        }
        
        public void playSound()
        {
             wave.Init();
             wave.Play();
        }
    }
