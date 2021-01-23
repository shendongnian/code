    class MyMediaPlayer : MediaPlayer
    {
        private bool looping;
     
        public MyMediaPlayer() : base()
        {
            looping = false;  
            base.MediaEnded += new EventHandler(mediaEnded);
        }
        public MyMediaPlayer(string _file) : base()
        {
            looping = false;
            base.Open(new Uri(_file, UriKind.Relative));
            base.MediaEnded += new EventHandler(mediaEnded);
        }   
        public bool Looping
        {
            get { return looping;}
            set { looping = value; }
        }
        public void playLooping()
        {
            looping = true;
            base.Play();
        }
        public void playLooping(file _file)
        {
            looping = true;
            base.Open(new Uri(_file, UriKind.Relative));
            base.Play();
        }
        public void play()
        {
            looping = false;
            base.Play();
        }
        public void play(string _file)
        {
            looping = false;
            base.Open(new Uri(_file, UriKind.Relative));
            base.Play();
        }
        public void stop()
        {
            looping = false;
            base.Stop();
        }
        private void mediaEnded(object sender, EventArgs e)
        {
            if(looping)
            {
                base.Position = new TimeFrame(0, 0, 0);
                base.Play();
            }
        }
   
    }
