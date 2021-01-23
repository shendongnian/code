    public static DependencyProperty ScoreProperty = 
        DependencyProperty.Register("Score", typeof(int), typeof(BgBoard));
    public int Score
    {
        get { return (int)GetValue(ScoreProperty); }
        set { SetValue(ScoreProperty, value); }
    }
    public BgBoard()
    {
        Score = 999;
        InitializeComponent(); 
    } 
