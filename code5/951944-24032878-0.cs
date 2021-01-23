            string url = "http://traffic.libsyn.com/slashfilmcast/Davidmichod.mp3";//your url link
            // Constructor
            public MainPage()
            {
                InitializeComponent();
                Microsoft.Xna.Framework.FrameworkDispatcher.Update();
                Song track = Song.FromUri("Sample Song", new Uri(url));
                MediaPlayer.Play(track);
     
            }
