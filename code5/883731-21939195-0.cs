    public MainPage()
        {
    
            this.InitializeComponent();
    
            QualityChoices.Add(YouTubeQuality.Quality.Low);
            QualityChoices.Add(YouTubeQuality.Quality.Medium);
            QualityChoices.Add(YouTubeQuality.Quality.High);
    
            PlayVideo(); 
    
        }
