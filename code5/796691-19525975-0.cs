    public class MovieForm : Form
    {
        private MovieForm _instance;
        private MovieForm()...
        public static MovieForm Instance
        {
            get
            {
                if (_instance == null) _instance = new MovieForm();
                return _instance;
            }
        }
        public void Play()...
        public void Play(Url movieUrl)...
        public void Pause()...
        public void Stop()...
    }
