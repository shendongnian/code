        private NAudio.Wave.WaveFileReader wave = new NAudio.Wave.WaveFileReader(Properties.Resources.bgm);
        private NAudio.Wave.DirectSoundOut outs = null;
        public void PlayBGM()
        {
            if (outs == null)
            {
                outs = new NAudio.Wave.DirectSoundOut();
                outs.Init(new NAudio.Wave.WaveChannel32(wave));
            }
            outs.Play();
        }
